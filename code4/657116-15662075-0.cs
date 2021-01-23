    public class PlainJsonStringConverter : Newtonsoft.Json.JsonConverter
    {
	    public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return reader.Value;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var stringValue = (string)value;
            writer.WriteRawValue(stringValue);
        }
    }
    public class MyViewModel
    {
        public string id { get; set; }
        [Newtonsoft.Json.JsonConverter(typeof(PlainJsonStringConverter))]
        public string images { get; set; }
        /* ...  */
    }
