    void AThread()
    {
        Monitor.Enter(this);
        try
        {
            // Do protected work
        }
        finally
        {
            Monitor.Exit(this);
        }
        // Do unprotected work
    }
