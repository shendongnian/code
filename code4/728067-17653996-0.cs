    public delegate void AsyncMethodCaller(strind inputdata);
     void someMethod()
    {
	//
	// ... some actions	
	//
 	AsyncMethodCaller caller = new AsyncMethodCaller(this.ProcessInputData);
       // Initiate the asychronous call.
       IAsyncResult result = caller.BeginInvoke("my data");
    }
    void ProcessInputData(string inputData)
    {
    	// some actions
    }
    
