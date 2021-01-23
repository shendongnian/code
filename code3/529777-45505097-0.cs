    public class Response
    {
        [JsonProperty(PropertyName = "variations")]
        [JsonConverter(typeof(EmptyArrayOrDictionaryConverter))]
        public Dictionary<int, Variation> Variations { get; set; }
    }
    public class EmptyArrayOrDictionaryConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(typeof(Dictionary<string, object>));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Object)
            {
                return token.ToObject(objectType);
            }
            else if (token.Type == JTokenType.Array)
            {
                if (!token.HasValues)
                {
                    // create empty dictionary
                    return Activator.CreateInstance(objectType);
                }
            }
            throw new JsonSerializationException("Object or empty array expected");
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
