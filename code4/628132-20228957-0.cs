    public class SantaClausJsonTest
    {
        public SantaClausJsonTest()
        {
            Settings = new JsonSerializerSettings();
            Settings.TypeNameHandling = TypeNameHandling.Objects;
            Settings.Converters.Add(new SantaClaus2JsonConverter());
        }
        private JsonSerializerSettings Settings;
        [Fact]
        public void SerializeAndDeserialize()
        {
            var collection = new []
                {
                    new SantaClaus("St. Bob"),
                    new SantaClaus("St. Jim"),
                };
            var serialized = JsonConvert.SerializeObject(collection, Settings);
            Console.WriteLine(serialized);
            Assert.False(string.IsNullOrEmpty(serialized));
            var deserialized = JsonConvert.DeserializeObject<SantaClaus[]>(serialized, Settings);
            Console.WriteLine(deserialized.GetType().ToString());
            Assert.NotNull(deserialized);
            Assert.True(deserialized.Any(a => a.Name == "St. Bob"));
            Assert.True(deserialized.Any(a => a.Name == "St. Jim"));
        }
    }
    public class SantaClaus
    {
        public SantaClaus(string santaClauseName)
        {
            Name = santaClauseName;
        }
        public string Name { get; private set; }
    }
    public class SantaClaus2JsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(SantaClaus);
        }
        /// <summary>
        /// Deserializes a SantaClaus as a SantaClausEx which has a matching constructor that allows it to deserialize naturally.
        /// </summary>       
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var name = string.Empty;
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.String && reader.Path.EndsWith("Name"))
                {
                    name = reader.Value as string;
                }
                if (reader.TokenType == JsonToken.EndObject)
                {
                    break;
                }
            }
            return Activator.CreateInstance(objectType, name);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
        public override bool CanRead
        {
            get
            {
                return true;
            }
        }
        public override bool CanWrite
        {
            get
            {
                return false;//We only need this converter when reading.
            }
        }
