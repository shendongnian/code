	public class ZonedDateTimeSerializer : IBsonSerializer<ZonedDateTime>
	{
		public static ZonedDateTimeSerializer Instance { get; } = new ZonedDateTimeSerializer();
		object IBsonSerializer.Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
		{
			return Deserialize(context, args);
		}
		public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, ZonedDateTime value)
		{
			if (value == null)
				throw new ArgumentNullException(nameof(value));
			var zonedDateTime = value;
			SerializeAsDocument(context, zonedDateTime);
		}
		private static void SerializeAsDocument(BsonSerializationContext context, ZonedDateTime zonedDateTime)
		{
			context.Writer.WriteStartDocument();
			context.Writer.WriteString("tz", zonedDateTime.Zone.Id);
			context.Writer.WriteInt64("ticks", zonedDateTime.ToInstant().Ticks);
			context.Writer.WriteEndDocument();
		}
		public ZonedDateTime Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
		{
			var bsonType = context.Reader.GetCurrentBsonType();
			if (bsonType != BsonType.Document)
			{
				throw new InvalidOperationException($"Cannot deserialize ZonedDateTime from BsonType {bsonType}.");
			}
			context.Reader.ReadStartDocument();
			var timezoneId = context.Reader.ReadString("tz");
			var ticks = context.Reader.ReadInt64("ticks");
			var timezone = DateTimeZoneProviders.Tzdb.GetZoneOrNull(timezoneId);
			if (timezone == null)
			{
				throw new Exception($"Unknown timezone id: {timezoneId}");
			}
			context.Reader.ReadEndDocument();
			return new Instant(ticks).InZone(timezone);
		}
		public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
		{
			if (value == null)
			{
				throw new ArgumentNullException(nameof(value));
			}
			var zonedDateTime = (ZonedDateTime)value;
			SerializeAsDocument(context, zonedDateTime);
		}
		public Type ValueType => typeof(ZonedDateTime);
	}
