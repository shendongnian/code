    public static class StringParsers
    {
    	private static Dictionary<Type, object> Parsers = new Dictionary<Type, object>();
    	
    	public static void RegisterParser<T>(Func<string, T> parseFunction)
    	{
    		Parsers[typeof(T)] = parseFunction;
    	}
    
    	public static T Parse<T>(string input)
    	{
    		object untypedParser;
    		if (!Parsers.TryGetValue(typeof(T), out untypedParser))
    			throw new Exception("Could not find a parser for type " + typeof(T).FullName);
    			
    		Func<string, T> parser = (Func<string, T>)untypedParser;
    		
    		return parser(input);
    	}
    }
