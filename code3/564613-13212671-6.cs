    //Check to see BlockingCollection capacity has been exceeded.
    if (Tokens.Count > 50000)
    { 
        lock (syncLock)
        {   //Double check before waiting
            if (Tokens.Count > 50000)
            {
                Monitor.Wait(syncLock, 1000);
            }
        }
    }
