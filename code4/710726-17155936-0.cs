	public static T DeepClone<T>(T original)
	{
		if (!typeof(T).IsSerializable)
		{
			throw new ArgumentException("The type must be serializable.", "original");
		}
		if (ReferenceEquals(original, null))
		{
			return default(T);
		}
		using (var stream = new MemoryStream())
		{
			var formatter = new BinaryFormatter
			{
				Context = new StreamingContext(StreamingContextStates.Clone)
			};
			formatter.Serialize(stream, original);
			stream.Position = 0;
			return (T) formatter.Deserialize(stream);
		}
	}
