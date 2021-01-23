    void Main()
    {
    	WrapFunctionCall( () => DoSomething(5));
    	WrapFunctionCall( () => DoSomethingDifferent("tyto", 4));
    }
    
    public void DoSomething(int v){ /* logic */}
    
    public void DoSomethingDifferent(string v, int val){ /* another logic */}
    
    public void WrapFunctionCall(Action function) 
    {
    	try
        {
    		function();
    	}
    	catch(Exception e)
        {
             //a BUNCH of logic that is the same for all functions
        }
    }
