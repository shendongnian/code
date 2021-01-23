	public static bool TryParse(string input, out int? value)
	{
		return TryParse(input, Int32.TryParse, out value);
	}
	protected static bool TryParse(string input, out short? value)
	{
		return TryParse(input, Int16.TryParse, out value);
	}
	protected static bool TryParse(string input, out long? value)
	{
		return TryParse(input, Int64.TryParse, out value);
	}
	private static bool TryParse<T>(string input, TryParseFunc<T> tryParse, out T? value)
		where T : struct
	{
		T outValue;
		bool result = tryParse(input, out outValue);
		value = outValue;
		return result;
	}
	private delegate bool TryParseFunc<T>(string input, out T value);
