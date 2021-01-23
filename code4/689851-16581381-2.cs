	public static List<KeyValuePair<string, string>> GetEnumList<TEnum>() 
              where TEnum : struct, IConvertible
	{
		if (!typeof(TEnum).IsEnum)
			throw new ArgumentException("Type must be an enumeration");
		List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
		foreach (TEnum e in Enum.GetValues(typeof(TEnum)))
		{
			list.Add(new KeyValuePair<string, string>
			(
				e.ToString(), 
				e.ToType(Enum.GetUnderlyingType(typeof(TEnum)), null).ToString()
			));
		}
		return list;
	}
