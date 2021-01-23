    public class IHtmlStringConverter : Newtonsoft.Json.JsonConverter {
        public override bool CanConvert(Type objectType) {
            return typeof(IHtmlString).IsAssignableFrom(objectType);
        }
        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer) {
            IHtmlString source = value as IHtmlString;
            if (source == null) {
                return;
            }
            writer.WriteValue(source.ToString());
        }
        public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer) {
            // For whatever reason, if you ever want to deserialize from JSON into an IHtmlString, do so here.
            throw new NotImplementedException();
        }
    }
