    public class Converter : JsonConverter
    {
        public override bool CanRead { get { return false; } }
        public override bool CanWrite { get { return true; } }
       
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(SubCatalog);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
              //serialization code here
        }
    }
