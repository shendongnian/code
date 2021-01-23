    class TermsConverter : Newtonsoft.Json.JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Terms) == objectType;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Terms terms = (Terms)value;
            writer.WriteStartObject();
            writer.WritePropertyName("Term");
            writer.WriteValue(terms.Term);
            writer.WriteEndObject();
        }
    }
