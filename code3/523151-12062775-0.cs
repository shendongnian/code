    if(false == request.GetResponseAsync().Wait(DateTime.Now.AddMinutes(2.0)))
    {
        Trace.WriteLine("timeout");
        return;
    }
    //...
