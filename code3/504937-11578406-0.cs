	public static void LogPublicProperties(object obj)
	{
		foreach (var propertyInfo in d.GetType().GetProperties())
			Console.WriteLine("{0} = {1}",
				propertyInfo.Name,
				propertyInfo.GetValue(d, null));
	}
