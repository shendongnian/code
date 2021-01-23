        public class A
        {
            public int X { get; set; }
            [JsonProperty(ItemConverterType = typeof(BytesToHexConverter))]
            public byte[] Y { get; set; }
        }
        public class BytesToHexConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(byte[]);
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.String)
                {
                    var hex = serializer.Deserialize<string>(reader);
                    if (!string.IsNullOrEmpty(hex))
                    {
                        return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
                    }
                }
                return Enumerable.Empty<byte>();
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
            var json = sb.ToString();
            var sr = new StringReader(json);
            var readback = s.Deserialize(sr, typeof(A));
            Console.WriteLine(sw);
            Console.WriteLine("End...");
            Console.ReadLine();
        }
