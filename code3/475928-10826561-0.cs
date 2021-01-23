    public static void GetDataAsync(Action<int, int> callback)
    {
        // Two here because we are going to wait for 2 events- adjust accordingly
        var latch = new CountdownEvent(2);
        Object r1Data, r2Data;    
        Service.Instance.GetData(r1 =>
        {
            Debug.Assert(r1.Success);
            r1Data = r1.Data;
            latch.Signal();
        });
    
        Service.Instance.GetData2(r2 =>
        {
            Debug.Assert(r2.Success);
            r2Data = r2.Data;
            latch.Signal();
        });
    
        // How do I call the action "callback" without blocking when the two methods have finished to execute?
        // callback(r1.Data, r2.Data);
    
        ThreadPool.QueueUserWorkItem(() => {
            // This will execute on a threadpool thread, so the 
            // original caller is not blocked while the other async's run
            latch.Wait();
            callback(r1Data, r2Data);
            // Do whatever here- the async's have now completed.
        });
    }
