    public class MyClass
    {
    	protected static ConcurrentDictionary<string, double> Stocks {get; set;} 
    	
    	static MyClass()
    	{
    		Stocks = new ConcurrentDictionary<string, double>();
    	}
    }
