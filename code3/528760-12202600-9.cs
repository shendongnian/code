    public static void LoadInfo()        
    {        
        var service = new SomeWcfService();        
        // begin an asynchronous service call
        // and handle the results in this anonymous method
        service.BeginGetInfo(x =>
        {
            // B. This code block will be called when the service returns with results
            var results = (ar.AsyncState as SomeWcfService).EndGetInfo(ar);  
            // Do whetever you need with results here
        }, service);  
        // A. You can do other things here while the service call executes
        // but debugging this gets more complicated because things will likely
        // occur at A before they occur at B
    }
