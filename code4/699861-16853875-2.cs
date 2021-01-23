    private readonly object SyncRoot = new object();
    {
        lock (SyncRoot) { sentPings++; }
        ....
    }
    public void pingCompleted(object sender, PingCompletedEventArgs e)
    {
        //This counts recieved addresses 
        lock (SyncRoot) { recievedIpAddresses++; }
        if (e.Reply.Status == IPStatus.Success)
        {
            //Do something
        }
        else
        {
            /*Computer is down*/
        }
        lock (SyncRoot) { 
            //This checks if sent equals recieved
            if (recievedIpAddresses == sentPings )
            {
                //All returned
            }
        }
    }
