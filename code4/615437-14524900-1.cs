    public class MyBooleanConverter : JsonConverter
    {
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = reader.Value;
            if (value == null || String.IsNullOrWhiteSpace(value.ToString()))
            {
                return false;
            }
            if ("yes".Equals(value, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }
        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(String) || objectType == typeof(Boolean))
            {
                return true;
            }
            return false;
        }
    }
    public interface IUnit
    {
        string Name { get; }
   
        [JsonConverter(typeof(MyBooleanConverter))]
        bool isAvailable { get; }
    }
