     /// <summary>
        /// Indicates to Newtonsoft.Json how to deserialize:
        /// - interfaces to concrete classes
        /// - how to deserialize collections of interfaces to concrete classes
        /// - how to deserialize collections of KeyValuePairs (for non-valid identifiers JSON properties) into Dictionary or Collections
        /// See:
        ///      http://stackoverflow.com/questions/5780888/casting-interfaces-for-deserialization-in-json-net
        ///      http://stackoverflow.com/questions/9452901/cannot-deserialize-json-array-into-type-json-net
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <typeparam name="TConcrete"></typeparam>
    public class GenericJsonConverter<TInterface, TConcrete> : JsonConverter where TConcrete : TInterface
    {
        public override bool CanConvert(Type objectType)
        {
            return
                 objectType == typeof(Collection<TInterface>)
              || objectType == typeof(TInterface)
              || objectType == typeof(Collection<KeyValuePair<string, TInterface>>)
              || objectType == typeof(Dictionary<string, TInterface>)
              ;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (objectType == typeof(Collection<TInterface>))
            {
                return new Collection<TInterface>(serializer.Deserialize<Collection<TConcrete>>(reader).OfType<TInterface>().ToList());
            }
            if (objectType == typeof(TInterface))
            {
                return serializer.Deserialize<TConcrete>(reader);
            }
            if ((objectType == typeof(Collection<KeyValuePair<string, TInterface>>))
            || (objectType == typeof(Dictionary<string, TInterface>)))
            {
                var isDictionary = (objectType == typeof(Dictionary<string, TInterface>));
                Collection<KeyValuePair<string, TInterface>> deserializedObject = new Collection<KeyValuePair<string, TInterface>>();
                reader.Read(); // Skips the '{' token at the beginning of the JSON object
                while (reader.TokenType == JsonToken.PropertyName)
                {
                    var id = reader.Value.ToString();  // Contains the property value => for invalid JSONs properties it's an ID (e.g. number or GUID)
                    reader.Read(); // Skips the '{' token of the inner object
                    var instaceOfConcreteType = serializer.Deserialize<TConcrete>(reader);
                    deserializedObject.Add(new KeyValuePair<string, TInterface>(id, instaceOfConcreteType));
                    reader.Read(); // Skips the '{' token at the beginning of the JSON object
                }
                var result = isDictionary ? deserializedObject.ToDictionary(kvp => kvp.Key, kvp => kvp.Value) : (object)deserializedObject;
                return result;
            }
            throw new NotSupportedException("Cannot Deserialize type:" + objectType);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
                return;
            // TODO: Verify if value.GetType() is compatible with TConcrete before forcing a cast
            if (value.GetType() == typeof(TInterface))
                serializer.Serialize(writer, (TConcrete)value);
            throw new NotSupportedException("Cannot serialize type:" + value.GetType());
        }
    }
