    private static object lockobj = new object();
    public bool DoWorkIfNotBusy()
    {
        bool lockWasTaken = false;
        var temp = lockobj;
        try
        {
            Monitor.TryEnter(temp, ref lockWasTaken);
            {
                //Do work here.. 
                //Believe it or not, the brackets in which this work is in is important.
                //The brackets are to resolve a race condition.
            }
        }
        finally
        {
            if (lockWasTaken) Monitor.Exit(temp);
        }
        return lockWasTaken;
    }
