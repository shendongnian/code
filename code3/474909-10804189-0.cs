    [Flags]
    private enum TestEnum
    {
    	Value1 = 1,
    	Value2 = 2
    }
    
    static void Main(string[] args)
    {
    	var enumName = "Value1";
    	TestEnum enumValue;
    
    	if (!TestEnum.TryParse(enumName, out enumValue))
    	{
    		throw new Exception("Wrong enum value");
    	}
    
    	// enumValue contains parsed value
    }
