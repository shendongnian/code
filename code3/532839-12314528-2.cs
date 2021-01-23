    private int _running = 1;
    public void Stop()
    {
        Interlocked.Exchange(ref _running, 0);
    }
