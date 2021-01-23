    private static AutoResetEvent DoneTraces = new AutoResetEvent(false);
    
    private void GetTraceData()
    {
        do
    {
        byte[] receivedbytes = new byte[1];
        if (Connection.ReadData(receivedbytes) && receivedbytes[0] == 192)
            ProcessIncomingTrace();
    
        Thread.Sleep(100);
    }
    while (RunTraceQueryWorker)
         
    Thread.Sleep(200);
    DoneTraces.Set();
    
    }
    
    private void StartGettingTraceData()
    {
        RunTraceQueryWorker = true;
        new Thread(GetTraceData).Start();
    }
    
    private bool StopGettingTraceData()
    {
        RunTraceQueryWorker = false;
        bool timedOut = !DoneTraces.WaitOne(10000);
        return timedOut;
    }
