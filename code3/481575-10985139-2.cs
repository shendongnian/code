    public class JsonToArrayConverter<T> : CustomCreationConverter<T[]>
    {
        public override T[] Create(Type objectType)
        {
            // Default value is an empty array.
            return new T[0];
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object
            existingValue, JsonSerializer serializer)
        {
    
            if (reader.TokenType == JsonToken.StartArray)
            {
                // JSON object was an array, so just deserialize it as usual.
                object result = serializer.Deserialize(reader, objectType);
                return result;
            }
            else
            {
                // JSON object was not an arry, so deserialize the object
                // and wrap it in an array.
                var resultObject = serializer.Deserialize<T>(reader);
                return new T[] {resultObject};
            }
        }
    }
