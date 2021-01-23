    BsonSerializer.RegisterSerializer(typeof(DateTime), new MyMongoDBDateTimeSerializer());
    public class MyMongoDBDateTimeSerializer : DateTimeSerializer
    {
        //  MongoDB returns datetime as DateTimeKind.Utc, which cann't be used in our timezone conversion logic
        //  We overwrite it to be DateTimeKind.Unspecified
        public override object Deserialize(MongoDB.Bson.IO.BsonReader bsonReader, System.Type nominalType, MongoDB.Bson.Serialization.IBsonSerializationOptions options)
        {
            var obj = base.Deserialize(bsonReader, nominalType, options);
            var dt = (DateTime) obj;
            return new DateTime(dt.Ticks, DateTimeKind.Unspecified);
        }
        //  MongoDB returns datetime as DateTimeKind.Utc, which cann't be used in our timezone conversion logic
        //  We overwrite it to be DateTimeKind.Unspecified
        public override object Deserialize(MongoDB.Bson.IO.BsonReader bsonReader, Type nominalType, Type actualType, MongoDB.Bson.Serialization.IBsonSerializationOptions options)
        {
            var obj = base.Deserialize(bsonReader, nominalType, actualType, options);
            var dt = (DateTime)obj;
            return new DateTime(dt.Ticks, DateTimeKind.Unspecified);
        }
        //  MongoDB stores all datetime as Utc, any datetime value DateTimeKind is not DateTimeKind.Utc, will be converted to Utc first
        //  We overwrite it to be DateTimeKind.Utc, becasue we want to preserve the raw value
        public override void Serialize(MongoDB.Bson.IO.BsonWriter bsonWriter, System.Type nominalType, object value, MongoDB.Bson.Serialization.IBsonSerializationOptions options)
        {
            var dt = (DateTime) value;
            var utcValue = new DateTime(dt.Ticks, DateTimeKind.Utc);
            base.Serialize(bsonWriter, nominalType, utcValue, options);
        }
    }
