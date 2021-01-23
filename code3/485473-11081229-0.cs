    var str= JsonConvert.SerializeObject(
         new {s="aaa",d=(decimal)3131313},
         new MyConverter());
-
    public class MyConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(decimal)) return true;
            return false;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(Convert.ToInt64(value));
        }
    }
