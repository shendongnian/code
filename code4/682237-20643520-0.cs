    public class FlexibleCollectionConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartArray)
            {
                return serializer.Deserialize(reader, objectType);
            }
            var array = new JArray(JToken.ReadFrom(reader));
            return array.ToObject(objectType);
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof (IEnumerable).IsAssignableFrom(objectType);
        }
    }
