    public class OptionalJsonConverter<T> : JsonConverter
    {
        public static OptionalJsonConverter<T> Instance = new OptionalJsonConverter<T>();
        public override void WriteJson( JsonWriter writer, object value, JsonSerializer serializer )
        {
            var optional = (Optional<T>)value; // Cast so we can access the Optional<T> members
            serializer.Serialize( writer, optional.Value );
        }
        public override object ReadJson( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer )
        {
            var valueType = objectType.GetGenericArguments()[ 0 ];
            var innerValue = (T)serializer.Deserialize( reader, valueType );
            return (Optional<T>)innerValue; // Explicitly invoke the conversion from T to Optional<T>
        }
        public override bool CanConvert( Type objectType )
        {
            return objectType == typeof( Optional<T> );
        }
    }
