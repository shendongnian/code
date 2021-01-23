        public class BytesToHexConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(byte[]);
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                var bytes = value as byte[];
                var @string = BitConverter.ToString(bytes).Replace("-", string.Empty);
                serializer.Serialize(writer, @string);
            }
        }
        public static void Main(string[] args)
        {
            var a = new A() { X = 1001, Y = new byte[] { 0, 1, 4, 8 } };
            var s = new JsonSerializer();
            var sb = new StringBuilder();
            var sw = new StringWriter(sb);
            s.Converters.Add(new BytesToHexConverter());
            s.Serialize(sw, a);
            Console.WriteLine(sw);
            Console.WriteLine("End...");
            Console.ReadLine();
        }
