    private int _finished = 0;
    public bool Finished
    {
        get { return _finished > 0; }
        set
        {
            Interlocked.Exchange(ref _finished, value ? 1 : 0);
        }
    }
