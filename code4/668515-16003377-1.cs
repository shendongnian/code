    public void Execute(CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        while (true)
        {
            // processing
            ct.ThrowIfCancellationRequested();
        }
    }
