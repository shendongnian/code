    void KillSelf()
    {
        try
        {
            // Code to close open connections/dispose 
            // of unmanaged resources etc
            ...
        }
        finally
        {
            Environment.Exit(1);
        }
    }
