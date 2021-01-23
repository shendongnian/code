    private void OnReceiveData(IAsyncResult Result)
    {
        int ByteCount = 0;
        try
        {
            if (mSocket != null)
            {
                ByteCount = mSocket.EndReceive(Result);
            }
        }
        catch (Exception) { }
    
        if (ByteCount < 1 || ByteCount >= mBuffer.Length)
        {
            SessionManager.StopSession(mId);
            return;
        }
    
        ThreadPool.QueueUserWorkItem(ProcessDataInThread, ByteCount);
    }
    void ProcessDataInThread(object context)
    {
        int ByteCount = (int)context;
        
        ProcessData(ByteUtil.ChompBytes(mBuffer, 0, ByteCount));
        BeginReceive();
    }
