    void Main()
    {
    	string methodName = "SomeMethod";
    	
    	var methodInfo = this.GetType().GetMethod(methodName);
    	
    	Func<int, string> myFunc = integerVal => (string) methodInfo.Invoke(this, new object[]{integerVal});
    	
    	Console.WriteLine (myFunc(5));
    	
    }
    
    public string SomeMethod(int val)
    {
    	return val.ToString() + " value";
    }
