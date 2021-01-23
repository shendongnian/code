    void Main()
    {
    	var result = WrapFunctionCallWithReturn( () => DoSomething(5));
    	var differentResult = WrapFunctionCallWithReturn( () => DoSomethingDifferent("tyto", 4));
    }
    
    public int DoSomething(int v){ return 0; }
    
    public string DoSomethingDifferent(string v, int val){ return "tyto"; }
    
    public T WrapFunctionCallWithReturn<T>(Func<T> function) 
    {
    	try
        {
    		return function();
    	}
    	catch(Exception e)
    	{
    		//a BUNCH of logic that is the same for all functions
    		throw;
    	}
    }
