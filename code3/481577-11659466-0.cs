    public class SingleToArrayConverter<T> : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var items = (IEnumerable<T>)value;
            if (value == null || !items.Any())
            {
                writer.WriteNull();
            }
            else if (items.Count() == 1)
            {
                serializer.Serialize(writer, items.ElementAt(0));
            }
            else
            {
                serializer.Serialize(writer, items);
            }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (!CanConvert(objectType))
            {
                throw new NotSupportedException();
            }
            if (reader.TokenType == JsonToken.Null)
            {
                reader.Skip();
                return null;
            }
            else if (reader.TokenType == JsonToken.StartObject)
            {
                return new T[] { serializer.Deserialize<T>(reader) };
            }
            else
            {
                return serializer.Deserialize<T[]>(reader);
            }
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IEnumerable<T>);
        }
    }
