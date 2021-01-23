    public void doStart(CancellationToken token)
    {
        while(...)
        {
            ...
            if (token.IsCancellationRequested)
                break;
        }
    }
