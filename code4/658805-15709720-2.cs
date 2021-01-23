    void UploadProc(object state)
    {
        if (!Monitor.TryEnter(uploadLock))
        {
            // upload in progress. Quit.
            return;
        }
        try
        {
            // processing here
        } 
        finally
        {
            Monitor.Exit(uploadLock);
        }
    }
