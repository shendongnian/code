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
            // warning, not thoroughly tested
            var html = reader.Value as string;
            return html == null ? null : System.Web.Mvc.MvcHtmlString.Create(html);
        }
    }
