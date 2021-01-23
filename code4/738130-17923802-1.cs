    public class ResultConverter: JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Result);
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Boolean)
            {
                return new Result
                {
                    Value = (bool)reader.Value,
                };
            }
    
            return new Result
            {
                Items = serializer.Deserialize<Item[]>(reader),
            };
        }
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // If you want to support serializing you could implement this method as well
            throw new NotImplementedException();
        }
    }
