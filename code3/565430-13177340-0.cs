    public class VersionConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // default serialization
            serializer.Serialize(writer, value);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // create a new Version instance and pass the properties to the constructor
            // (you may also use dynamics if you like)
            var dict = serializer.Deserialize<Dictionary<string, int>>(reader);
            return new Version(dict["Major"], dict["Minor"], dict["Build"], dict["Revision"]);
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Version);
        }
    }
