    void Main()
    {
    	string methodName = "SomeMethod";
    	
    	var methodInfo = this.GetType().GetMethod(methodName);
    	
    	Action<string> myFunc = str => methodInfo.Invoke(this, new object[]{str});
    	
    	MyEvent += myFunc;
    	
    	MyEvent("value");
    	
    }
    public event Action<string> MyEvent = delegate{}; 
                                        //default so that not to check for null
    
    public void SomeMethod(string val)
    {
    	Console.WriteLine ("event called with: " + val);
    }
