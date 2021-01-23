    public void Execute(CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        while (true)
        {
            // processing
            // ...
             
            // need to cancel?
            ct.ThrowIfCancellationRequested();
        }
    }
