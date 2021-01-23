    {
		object result;
		BinaryReader ...;
		foreach (var propertyInfo in ...)
		{
			Func<BinaryReader, object> deserializer;
			if (!supportedTypes.TryGetValue(propertyInfo.PropertyType, out deserializer))
			{
				throw new NotSupportedException(string.Format(
					"Type of property '{0}' isn't supported ({1}).", propertyInfo.Name, propertyInfo.PropertyType));
			}
			
			var deserialized = deserializer(reader);
			propertyInfo.SetValue(result, deserialized, null);
		}
	}
	
	private static Dictionary<Type, Func<BinaryReader, object>> supportedTypes = new Dictionary<Type, Func<BinaryReader, object>>
	{
		{ typeof(int), br => br.ReadInt32() },
        // etc
	};
