    [TestFixture]
    public class CustomJsonSerialization
    {
        [Test]
        public void Test()
        {
            string serializeObject = JsonConvert.SerializeObject(true, new BoolConverter());
            Assert.That(serializeObject, Is.EqualTo("1"));
            var deserializeObject = JsonConvert.DeserializeObject<bool>(serializeObject, new BoolConverter());
            Assert.That(deserializeObject, Is.True);
        }
    }
    public class BoolConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((bool)value) ? 1 : 0);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return reader.Value.ToString() == "1";
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(bool);
        }
    }
