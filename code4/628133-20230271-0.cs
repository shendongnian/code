    public class SantaClaus2JsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(SantaClaus);
        }
        /// <summary>
        /// Deserializes a SantaClaus as a SantaClausEx which has a matching constructor that allows it to deserialize naturally.
        /// </summary>       
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            //temporarily switch off name handling so it ignores "SantaClaus" type when
            //explicitely deserialize as SantaClausEx
            //This could cause issues with nested types however in a more complicated object graph
            var temp = serializer.TypeNameHandling;
            serializer.TypeNameHandling = TypeNameHandling.None;
            var desr = serializer.Deserialize<SantaClausEx>(reader);
            serializer.TypeNameHandling = temp;//restore previous setting
            return desr;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new NotSupportedException();
        }
        public override bool CanRead { get { return true; } }
        public override bool CanWrite { get { false; } } //only for reading
    }
