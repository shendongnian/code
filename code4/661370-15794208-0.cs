    [JsonConverter(typeof(MyCustomClassConverter))]
    public class MyCustomClass
    {
      internal class MyCustomClassConverter : JsonConverter
      {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
          throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
          JObject jObject = JObject.Load(reader);
          foreach (var prop in jObject)
          {
            return new MyCustomClass { Key = prop.Key, Value = prop.Value.ToString() };
          }
          return null;
        }
        public override bool CanConvert(Type objectType)
        {
          return typeof(MyCustomClass).IsAssignableFrom(objectType);
        }
      }
      public string Key { get; set; }
      public string Value { get; set; }
    }
