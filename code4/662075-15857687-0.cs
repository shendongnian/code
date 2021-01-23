    class StringFormatConverter : JsonConverter
    {
        public string Format { get; set; }
        public override void WriteJson (JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(string.Format(Format, value));
        }
        public override object ReadJson (JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
        public override bool CanConvert (Type objectType)
        {
            return objectType == typeof(string);
        }
    }
