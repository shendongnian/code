    interface IJsonLinkable
    {
        string Id { get; }
    }
    class JsonRefConverter : JsonConverter
    {
        public override void WriteJson (JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((IJsonLinkable)value).Id);
        }
        public override object ReadJson (JsonReader reader, Type type, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.String)
                throw new Exception("Ref value must be a string.");
            return JsonLinkedContext.GetLinkedValue(serializer, type, reader.Value.ToString());
        }
        public override bool CanConvert (Type type)
        {
            return type.IsAssignableFrom(typeof(IJsonLinkable));
        }
    }
    class JsonRefedConverter : JsonConverter
    {
        public override void WriteJson (JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
        public override object ReadJson (JsonReader reader, Type type, object existingValue, JsonSerializer serializer)
        {
            var jo = JObject.Load(reader);
            var value = JsonLinkedContext.GetLinkedValue(serializer, type, (string)jo.PropertyValues().First());
            serializer.Populate(jo.CreateReader(), value);
            return value;
        }
        public override bool CanConvert (Type type)
        {
            return type.IsAssignableFrom(typeof(IJsonLinkable));
        }
    }
