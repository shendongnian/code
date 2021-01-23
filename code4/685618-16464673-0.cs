    private void GetTraceData()
    {
        byte[] receivedbytes = new byte[1];
    
        while( RunTraceQueryWorker )
        {
            if( Connection.ReadData(receivedbytes) && receivedbytes[0] == 192 )
            {
                ProcessIncomingTrace();
            }
            Sleep(100);
        }
    
        Thread.Sleep(200);
        DoneTraces.Set();
    }
