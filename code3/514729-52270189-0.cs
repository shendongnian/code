    private class SerializationTest
    {
        public byte[] Bytes => new byte[] { 11, 22, 33, 44, 0xAA, 0xBB, 0xCC };
    }
    private class ByteArrayHexConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(byte[]);
        public override bool CanRead => false;
        public override bool CanWrite => true;
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) => throw new NotImplementedException();
        private readonly string _separator;
        public ByteArrayHexConverter(string separator = ",") => _separator = separator;
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var hexString = string.Join(_separator, ((byte[])value).Select(p => p.ToString("X2")));
            writer.WriteValue(hexString);
        }
    }
    private static void Main(string[] args)
    {
        var setting = new JsonSerializerSettings { Converters = { new ByteArrayHexConverter() } };
        var json = JsonConvert.SerializeObject(new SerializationTest(), setting);
        Console.WriteLine(json); // {"Bytes":"0B,16,21,2C,AA,BB,CC"}
    }
