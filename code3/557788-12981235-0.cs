    public static object CounterLock = new object();
    ...
    lock ( CounterLock )
    {
        Counter++;
    }
    ...
