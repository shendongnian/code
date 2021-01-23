    class FooCollectionSurrogate
    {
        // the collection of foo elements
        public Foo[] Collection { get; set; }
        // the properties of FooCollection to serialize
        public string Bar { get; set; }
    }
    public class FooCollectionConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(FooCollection);
        }
        public override object ReadJson(JsonReader reader, Type objectType, 
                                        object existingValue, JsonSerializer serializer)
        {
            // N.B. null handling is missing
            var surrogate = serializer.Deserialize<FooCollectionSurrogate>(reader);
            var fooElements = surrogate.Collection;
            var fooColl = new FooCollection { Bar = surrogate.Bar };
            foreach (var el in fooElements)
                fooColl.Add(el);
            return fooColl;
        }
        public override void WriteJson(JsonWriter writer, object value, 
                                       JsonSerializer serializer)
        {
            // N.B. null handling is missing
            var fooColl = (FooCollection)value;
            // create the surrogate and serialize it instead of the collection itself
            var surrogate = new FooCollectionSurrogate() { Collection = fooColl.ToArray(), 
                                                           Bar = fooColl.Bar };
            serializer.Serialize(writer, surrogate);
        }
    }
