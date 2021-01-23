    private object _syncObject = new Object();
    void MyMethod()
    {
        if (!Monitor.TryEnter(_syncObject, TimeSpan.FromSeconds(5)))
        {
            return; // couldn't get the lock
        }
        try
        {
            // got the lock. Do stuff here
        }
        finally
        {
            Monitor.Exit(); // release the lock
        }
    }
