    public enum MyEnum
    {
    	Value1 = 1,
    	Value2 = 2,
    	Value3 = 3
    }
    
    private static void Main(string[] args)
    {
    	int myValueToCast = 3;
    	string myValueAsString = "Value1";
    	MyEnum myValueAsEnum = (MyEnum)myValueToCast;   // Will be Value3
    
    	MyEnum myValueAsEnumFromString;
    	if (Enum.TryParse<MyEnum>(myValueAsString, out myValueAsEnumFromString))
    	{
    		// Put logic here
            // myValueAsEnumFromString will be Value1
    	}
    
    	Console.ReadLine();
    }
