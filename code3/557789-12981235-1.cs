    public static readonly object CounterLock = new object();
    ...
    lock ( CounterLock )
    {
        Counter++;
    }
    ...
