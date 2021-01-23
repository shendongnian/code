    public class TermConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var field = value.GetType().Name;
            writer.WriteStartObject();
            writer.WritePropertyName(field);
            writer.WriteValue((value as ITerm)?.Name);
            writer.WriteEndObject();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            var properties = jsonObject.Properties().ToList();
            var value = (string) properties[0].Value;
            return properties[0].Name.Equals("Value") ? (ITerm) new Value(value) : new Variable(value);
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof (ITerm) == objectType || typeof (Value) == objectType || typeof (Variable) == objectType;
        }
    }
