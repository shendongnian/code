    public static Object LoadInfo()
    {
        // this is our semaphore
        var blocker = new AutoResetEvent();
        object result = null;
        var service = new SomeWcfService();
        // use a lambda instead of a method as the callback.
        // this will result in a closure where we can access the result and blocker variables
        service.BeginGetInfo(x => 
        {
            // We are on a different thread within this lambda
            result = (x.AsyncState as SomeWcfService).EndGetInfo(ar);
            // release anybody calling blocker.WaitOne
            blocker.Set(); 
        }, service);
        
        // we are still on the original thread here, and
        // BeginGetInfo has possibly not yet executed, so we must wait until Set is called
        blocker.WaitOne(Timeout.Infinite); 
        return result;
    }
