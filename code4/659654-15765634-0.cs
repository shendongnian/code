    public class CollectionOfIds : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return null;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            IList collection = (IList)value;
            List<int> ids = new List<int>();
            foreach (var item in collection)
            {
                dynamic itemCollection = (dynamic)item;
                ids.Add(itemCollection.ID);
            }
            serializer.Serialize(writer, ids);
        }
    }
