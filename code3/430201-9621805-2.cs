    static readonly object lock1 = new object();
    static readonly object lock2 = new object();
    static int counter = 0;
    static object M()
    {
        int c = Interlocked.Increment(ref counter);
        return c % 2 == 0 ? lock1 : lock2;
    }
    ...
    lock(M()) { Critical(); }
