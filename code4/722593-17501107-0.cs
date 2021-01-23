    public class PersonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Person).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType,
            object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            var isFemale = (bool)jObject["IsFemale"];
            Person target = isFemale ? (Person)new Female() : new Male();
            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }
        public override void WriteJson(JsonWriter writer, object value, 
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
