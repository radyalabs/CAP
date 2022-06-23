﻿// Copyright (c) .NET Core Community. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using DotNetCore.CAP.Abstractions;
using DotNetCore.CAP.Infrastructure;
using Newtonsoft.Json;

namespace DotNetCore.CAP.Internal
{
    internal class JsonContentSerializer : IContentSerializer
    {
        public JsonContentSerializer()
        {
            Helper.SetSerializerSettings(new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            });
        }

        public T DeSerialize<T>(string messageObjStr)
        {
            return Helper.FromJson<T>(messageObjStr);
        }

        public object DeSerialize(string content, Type type)
        {
            return Helper.FromJson(content, type);
        }

        public string Serialize<T>(T messageObj)
        {
            return Helper.ToJson(messageObj);
        }
    }
}