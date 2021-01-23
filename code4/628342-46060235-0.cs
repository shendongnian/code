    public class DictionaryToJsonObjectConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return typeof(IDictionary<string, string>).IsAssignableFrom(objectType);
            }
    
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
    
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                writer.WriteRawValue(JsonConvert.SerializeObject(value, Formatting.Indented));
            }
        }
