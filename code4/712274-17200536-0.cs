    public class FormatConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (objectType == typeof(int))
            {
                return Convert.ToInt32(reader.Value.ToString().Replace(".", string.Empty));
            }
    
            return reader.Value;
        }
    
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(int);
        }
    }
    [Test]
    public void ConvertJson()
    {
        const string Json = "{\"ProductCalcKey\":\"xxx\",\"PaperType\":\"1\",\"Quantity\":\"3.500\"}";
        var o = (UnitPrice)JsonConvert.DeserializeObject(Json, typeof(UnitPrice), new FormatConverter());
        Assert.AreEqual(3500, o.Quantity);
    }
