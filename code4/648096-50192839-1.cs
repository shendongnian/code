	public class ListConverter<I, T> : JsonConverter
	{
		public override bool CanWrite => false;
		public override bool CanRead => true;
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(I);
		}
		public override void WriteJson(JsonWriter writer,
			 object value, JsonSerializer serializer)
		{
			throw new InvalidOperationException("Use default serialization.");
		}
		public override object ReadJson(JsonReader reader,
			 Type objectType, object existingValue,
			 JsonSerializer serializer)
		{
			JArray jsonArray = JArray.Load(reader);
			var deserialized = (List<T>)Activator.CreateInstance(typeof(List<T>));
			serializer.Populate(jsonArray.CreateReader(), deserialized);
			return deserialized as IList<I>;
		}
	}
