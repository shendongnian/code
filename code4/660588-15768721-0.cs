    public delegate int Test<T>(T input) where T : struct;
    public static event Test<int> TestEvent;
    static void Main(string[] args)
    {
        var n = TestEvent(5);
    }
