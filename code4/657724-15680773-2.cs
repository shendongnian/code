    public static void Main()
    {
        Console.WriteLine("Loaded");
        Timer t = new Timer(TimerCallback, null, 0, 2000);
        Console.ReadKey();
    }
    private static void TimerCallback(Object o)
    {
        Console.WriteLine("In TimerCallback: " + DateTime.Now);
        GC.Collect();
    }
