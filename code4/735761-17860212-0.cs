    [TestMethod]
    public void Conversion()
    {
        var obj = new DualDate()
        {
            DateOne = new DateTime(2013, 07, 25),
            DateTwo = new DateTime(2013, 07, 25)
        };
        Assert.AreEqual("{\"DateOne\":\"07.25.2013\",\"DateTwo\":\"2013-07-25T00:00:00\"}", 
            JsonConvert.SerializeObject(obj, Formatting.None, new DualDateJsonConverter()));
    }
    class DualDate
    {
        public DateTime DateOne { get; set; }
        public DateTime DateTwo { get; set; }
    }
    class DualDateJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JObject result = new JObject();
            DualDate dd = (DualDate)value;
            result.Add("DateOne", JToken.FromObject(dd.DateOne.ToString("MM.dd.yyyy")));
            result.Add("DateTwo", JToken.FromObject(dd.DateTwo));
            result.WriteTo(writer);
        }
        // Other JsonConverterMethods
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DualDate);
        }
        public override bool CanWrite
        {
            get
            {
                return true;
            }
        }
        public override bool CanRead
        {
            get
            {
                return false;
            }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
