    /// <summary>
    /// Serializer for the Noda
    /// </summary>
    public class ZonedDateTimeSerializer : BsonBaseSerializer
    {
        private static ZonedDateTimeSerializer __instance = new ZonedDateTimeSerializer();
        /// <summary>
        /// Initializes a new instance of the ZonedDateTimeSerializer class.
        /// </summary>
        public ZonedDateTimeSerializer()
        {
        }
        /// <summary>
        /// Gets an instance of the ZonedDateTimeSerializer class.
        /// </summary>
        public static ZonedDateTimeSerializer Instance
        {
            get { return __instance; }
        }
        /// <summary>
        /// Deserializes an object from a BsonReader.
        /// </summary>
        /// <param name="bsonReader">The BsonReader.</param>
        /// <param name="nominalType">The nominal type of the object.</param>
        /// <param name="actualType">The actual type of the object.</param>
        /// <param name="options">The serialization options.</param>
        /// <returns>
        /// An object.
        /// </returns>
        public override object Deserialize(BsonReader bsonReader, Type nominalType, Type actualType, IBsonSerializationOptions options)
        {
            VerifyTypes(nominalType, actualType, typeof(ZonedDateTime));
            
            var bsonType = bsonReader.GetCurrentBsonType();
            if (bsonType == BsonType.DateTime)
            {
                var millisecondsSinceEpoch = bsonReader.ReadDateTime();
                return new Instant(millisecondsSinceEpoch).InUtc();
            }
            throw new InvalidOperationException(string.Format("Cannot deserialize ZonedDateTime from BsonType {0}.", bsonType));
        }
        /// <summary>
        /// Serializes an object to a BsonWriter.
        /// </summary>
        /// <param name="bsonWriter">The BsonWriter.</param>
        /// <param name="nominalType">The nominal type.</param>
        /// <param name="value">The object.</param>
        /// <param name="options">The serialization options.</param>
        public override void Serialize(BsonWriter bsonWriter, Type nominalType, object value, IBsonSerializationOptions options)
        {
            if (value == null)
                throw new ArgumentNullException("value");
            var ZonedDateTime = (ZonedDateTime)value;
            bsonWriter.WriteDateTime(ZonedDateTime.ToInstant().Ticks);
        }
    }
