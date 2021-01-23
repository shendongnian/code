    public class HardToSerializeSurrogate
    {
        public string IAmNotTheProblem { get; set; }
        public string ButIAm { get; set; }
    }
    public class HardToSerializeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(HardToSerialize);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var item = (HardToSerialize)value;
            // fill the surrogate with the values of the original object
            var surrogate = new HardToSerializeSurrogate();
            surrogate.IAmNotTheProblem = item.IAmNotTheProblem;
                
            serializer.Serialize(writer, surrogate);
        }
    }
