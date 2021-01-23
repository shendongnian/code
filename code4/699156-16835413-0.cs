    var list = JsonConvert.DeserializeObject<List<Class1>>(
                                "[{Id:5},{Id:0},{Id:null},{}]",
                                 new MyConverter());
    public class Class1
    {
        public int Id { get; set; }
    }
    public class MyConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(int);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null) return 0;
            return Convert.ToInt32(reader.Value);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
