    private ManualResetEvent _reset;
    public void Method1()
    {  
       _reset = new ManualResetEvent(true);
       for(int i=0; i<5; i++)
       {
           // Call the web service.
           // WaitOne blocks the current thread 
           _reset.WaitOne();
       }
    }
    public void CallBackMethod(int serviceResult)
    {
       // After getting the result...
       // Set allows waiting threads to continue
       _reset.Set();
    }
