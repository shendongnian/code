    class CustomIntConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(int));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JValue jsonValue = serializer.Deserialize<JValue>(reader);
            if (jsonValue.Type == JTokenType.Float)
            {
                return (int)Math.Round(jsonValue.Value<double>());
            }
            else if (jsonValue.Type == JTokenType.Integer)
            {
                return jsonValue.Value<int>();
            }
            throw new FormatException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
 
