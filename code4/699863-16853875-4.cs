    private readonly object SyncRoot = new object();
    public void MainMethod()
    {
        foreach (string str in ListContainingAddresses)
        { ... }
        lock (SyncRoot) { sentPings++; }
        ....
    }
    public void pingCompleted(object sender, PingCompletedEventArgs e)
    {
        //This counts recieved addresses 
        lock (SyncRoot) { recievedIpAddresses++; } // lock this if it is used on other threads
        if (e.Reply.Status == IPStatus.Success)
        {
            //Do something
        }
        else
        {
            /*Computer is down*/
        }
        lock (SyncRoot) { // lock this to ensure reading the right value of sentPings
            //This checks if sent equals recieved
            if (recievedIpAddresses == sentPings )
            {
                //All returned
            }
        }
    }
