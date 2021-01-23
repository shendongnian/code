    static void Main(string[] args)
    {
    	System.Threading.Thread myThread = new System.Threading.Thread(asyncCode);
    	myThread.Start(yourParameterObject);
    }
    
    static void asyncCode(object parameters)
    {
    	// Use the parameters passed
    }
