    // 30 second time out (or whatever you want)
    private static readonly TimeSpan TIMEOUT = TimeSpan.FromSeconds(30.0);
    
    // specify the maximum number of connection attempts
    private static readonly int MAX_RECONNECTS = 10;
    
    public void Connect() 
    {
        bool shouldListen = false;
        // This is your connect and re-connect loop
        for(int i = 0; i < MAX_RECONNECTS; i++)
        {
            try 
            {
                Client.Connect(IRCHelper.SERVER, IRCHelper.PORT);
                shouldListen = true;
            }
            catch (CouldNotConnectException e) 
            {
                // It's OK to sleep here, because you know exactly
                // how long you need to wait before you try and
                // reconnect
                Thread.Sleep((long)TIMEOUT.TotalMilliseconds);
                shouldListen = false;
            }
        }
        while(shouldListen)
        {
            try 
            {
                Client.Listen();
            }
            catch (Exception e) 
            {
                // Handle the exception
            }
        }
    }
