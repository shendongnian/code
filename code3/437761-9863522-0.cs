	public class StringToNIntConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(int?);
		}
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.Null)
				return null;
			if (reader.TokenType == JsonToken.Integer)
				return reader.Value;
			if (reader.TokenType == JsonToken.String)
			{
				if (string.IsNullOrEmpty((string)reader.Value))
					return null;
				int num;
				if (int.TryParse((string)reader.Value, out num))
					return num;
				throw new JsonReaderException(string.Format("Expected integer, got {0}", reader.Value));
			}
			throw new JsonReaderException(string.Format("Unexcepted token {0}", reader.TokenType));
		}
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			writer.WriteValue(value);
		}
	}
	public class MyClass
	{
		[JsonConverter(typeof(StringToNIntConverter))]
		public Int32? Id { get; set; }
		public string Description { get; set; }
	}
