    var json = JsonConvert.SerializeObject(new MyTestClass());
    public class MyTestClass
    {
        public string s = "iiiii";
        [JsonConverter(typeof(ByteArrayConvertor))]
        public byte[] buf = new byte[] {1,2,3,4,5};
    }
    public class ByteArrayConvertor : Newtonsoft.Json.JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType==typeof(byte[]);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            byte[] arr = (byte[])value;
            writer.WriteRaw(BitConverter.ToString(arr).Replace("-", ""));
        }
    }
