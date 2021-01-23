        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) 
        {
            writer.WriteValue(value.ToString().Replace("'", "\\'"));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) 
        {
            var value = JToken.Load(reader).Value<string>();
            return value.Replace("\\'", "'");
        }
        public override bool CanConvert(Type objectType) 
        {
            return objectType == typeof(string);
        }
    }
