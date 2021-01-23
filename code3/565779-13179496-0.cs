	public static string GetStringOfData<T>(List<T> list)
	{
		var stringBuilder = new StringBuilder();
		var properties = typeof(T).GetProperties()
            .Where(p => !p.GetIndexParameters().Any());
		foreach (var item in list)
		{
			foreach (var propertyInfo in properties)
			{
				stringBuilder.AppendFormat("{0}={1};",
											propertyInfo.Name,
											propertyInfo.GetValue(item, null));
			}
			stringBuilder.AppendLine();
		}
		return stringBuilder.ToString();
	}
