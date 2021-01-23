    void MethodWhichCallsAsyncMethod()
    {
        int foo = 1;
    
        AsyncCallback callback = result =>
        {
            Console.WriteLine(foo); // Access to foo
        };
    
        AsyncMethod(callback);
    }
    
    void AsyncMethod(AsyncCallback callback)
    {
        IAsyncResult result = null; // Compute result
        callback(result);
    }
