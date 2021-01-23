    public class ValueObjectConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(IValueObject).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return Activator.CreateInstance(objectType, serializer.Deserialize<string>(reader));
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var item = (IValueObject)value;
            writer.WriteValue(item.ToString());
            writer.Flush();
        }
    }
