    public class Vector2Converter : JsonConverter
    {
        public override bool CanConvert(Type objectType) {
            return (objectType == typeof(Vector2));
        }
        
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            JObject jsonObject = JObject.Load(reader);
            var properties = jsonObject.Properties().ToList();
            return new Vector2
            {
                X = (float)properties[0].Value,
                Y = (float)properties[1].Value
            };
        }
        
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            Vector2 v = (Vector2)value;
            writer.WriteStartObject();
            writer.WritePropertyName("X");
            serializer.Serialize(writer, v.X);
            writer.WritePropertyName("Y");
            serializer.Serialize(writer, v.Y);
            writer.WriteEndObject();
        }
    }
