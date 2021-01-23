    //Check to see BlockingCollection capacity is back a normal range.
    if (Tokens.Count <= 40000)
    { 
        lock (syncLock)
        {   //Double check before waiting
            if (Tokens.Count < 40000)
            {
                Monitor.PulseAll(syncLock);
            }
        }
    }
  
