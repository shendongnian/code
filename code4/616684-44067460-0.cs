    public class ConcreteTypeSerializer<TInterface, TImplementation> : BsonBaseSerializer where TImplementation : TInterface
    {
        private readonly Lazy<IBsonSerializer> _lazyImplementationSerializer;
    
        public ConcreteTypeSerializer()
        {
            var serializer = BsonSerializer.LookupSerializer(typeof(TImplementation));
        
            _lazyImplementationSerializer = new Lazy<IBsonSerializer>(() => serializer);
        }
        
        public override object Deserialize(BsonReader bsonReader, Type nominalType, Type actualType, IBsonSerializationOptions options)
        {
            if (bsonReader.GetCurrentBsonType() == BsonType.Null)
            {
                bsonReader.ReadNull();
                return default(TInterface);
            }
            else
            {
                return _lazyImplementationSerializer.Value.Deserialize(bsonReader, nominalType, typeof(TImplementation), options);
            }
        }
        public override void Serialize(BsonWriter bsonWriter, Type nominalType, object value, IBsonSerializationOptions options)
        {
            if (value == null)
            {
                bsonWriter.WriteNull();
            }
            else
            {
                var actualType = value.GetType();
                if (actualType == typeof(TImplementation))
                {
                    _lazyImplementationSerializer.Value.Serialize(bsonWriter, nominalType, (TImplementation)value, options);
                }
                else
                {
                    var serializer = BsonSerializer.LookupSerializer(actualType);
                    serializer.Serialize(bsonWriter, nominalType, value, options);
                }
            }
        }
    }
