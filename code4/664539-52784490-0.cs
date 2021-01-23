        public override object ReadJson(JsonReader reader,
            Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            Collection<T> result = new Collection<T>();
            var array = JArray.Load(reader);
            foreach (JObject jsonObject in array)
            { 
                var rule = default(T);
                var value = jsonObject.Value<string>("MyDistinguisher");
                MyEnum distinguisher;
                Enum.TryParse(value, out distinguisher);
                switch (distinguisher)
                {
                    case MyEnum.Value1:
                        rule = serializer.Deserialize<Type1>(jsonObject.CreateReader());
                        break;
                    case MyEnum.Value2:
                        rule = serializer.Deserialize<Type2>(jsonObject.CreateReader());
                        break;
                    default:
                        rule = serializer.Deserialize<Type3>(jsonObject.CreateReader());
                        break;
                }
                result.Add(rule);
            }
            return result;
        }
