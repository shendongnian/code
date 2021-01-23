    private static AutoResetEvent evt;
    public static Testing Instance = new Testing();
    private Testing()
    {
        evt = new AutoResetEvent(false);
        Create();
        evt.WaitOne();
        Console.WriteLine("out");
    }
