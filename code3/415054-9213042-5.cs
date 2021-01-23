    interface IParsable
    {
    	bool TryParse(string text);
    }
    
    class MyInt : IParsable
    {
    	public int Value { get; private set; }
    	
    	public static MyInt Parse(string text)
    	{
    		Parser parser = new Parser();
    		return parser.Parse<MyInt>(text);
    	}
    }
    
    class MyFloat : IParsable
    {
    	public float Value { get; private set; }
    	
    	public static MyFloat Parse(string text)
    	{
    		Parser parser = new Parser();
    		return parser.Parse<MyFloat>(text);
    	}
    }
    
    class Parser
    {
    	// The "new()" constraint means that T must have a
    	// parameterless constructor.
    	private T Parse<T>(string text)
    		where T : IParsable, new()
    	{
    		// Even though T isn't actually a type, we can use
    		// it as if it were, for the most part.
    		T obj = new T();
    		
    		// Because we had the IParsable constraint, we can
    		// use the TryParse method.
    		if (!obj.TryParse(text))
    		{
    			throw new Exception("Text could not be parsed.");
    		}
    		
    		return obj;
    	}
    }
	
