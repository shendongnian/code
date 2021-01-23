    private static int lastValue;
    public int LastValue
    {
        // This won't actually change the value - basically if the value *was* 0,
        // it gets set to 0 (no change). If the value *wasn't* 0, it doesn't get
        // changed either.
        get { return Interlocked.CompareExchange(ref lastValue, 0, 0); }
        set { Interlocked.Exchange(ref lastValue, value); }
    }
