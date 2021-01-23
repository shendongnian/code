    public void Execute(CancellationToken ct)
    {
        if (ct.IsCancellationRequested)
            return;
        while (true)
        {
            // processing
            if (ct.IsCancellationRequested)
                return;
        }
    }
