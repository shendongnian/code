    public static class DataConversion
    {
    	private static Dictionary<Type, ITryParser> Parsers;
    	
    	static DataConversion()
    	{
    		Parsers = new Dictionary<Type, ITryParser>();
    		AddParser<DateTime>(DateTime.TryParse);
    		AddParser<int>(Int32.TryParse);
    		AddParser<double>(Double.TryParse);
    		AddParser<decimal>(Decimal.TryParse);
    		AddParser<string>((string input, out string value) => {value = input; return true;});
    	}
    	
    	public static void AddParser<T>(TryParseMethod<T> parseMethod)
    	{
    		Parsers.Add(typeof(T), new TryParser<T>(parseMethod));
    	}
    	
    	public static bool Convert<T>(string input, out T value)
    	{
    		object parseResult;
    		bool success = Convert(typeof(T), input, out parseResult);
    		if (success)
    			value = (T)parseResult;
    		else
    			value = default(T);
    		return success;
    	}
    	
    	public static bool Convert(Type type, string input, out object value)
    	{
    		ITryParser parser;
    		if (Parsers.TryGetValue(type, out parser))
    			return parser.TryParse(input, out value);
    		else
    			throw new NotSupportedException(String.Format("The specified type \"{0}\" is not supported.", type.FullName));
    	}
    }
