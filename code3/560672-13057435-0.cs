    void Main()
    {
    	var sc = new SimpleClass();
    	var result = RangeCheck(0, 10, x => sc.Value = x );
    	System.Console.WriteLine(result);
    	System.Console.WriteLine(sc.Value);
    }
    
    public class SimpleClass
    {
    	public int Value { get; set; }
    }
    
    public bool RangeCheck<T>(int minVal, int maxVal, Func<int, T> someMethod)   
    {   
    	bool retval = true;   
    	try   
    	{   
    		for (int count = minVal; count <= maxVal; count++)   
    		{
    			//someMethod(count); //is not a range check,
    			//Did you mean
                someMethod(count - minValue);
    		}   
    	}   
    	catch   
    	{   
    		retval = false;   
    	}   
    	return retval;   
    }
