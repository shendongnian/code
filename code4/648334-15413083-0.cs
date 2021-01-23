    private static Action LongGetOrAdd(ConcurrentDictionary<int, string> dict, int index)
    {
        return () => dict.GetOrAdd
        (index,
         i =>
         {
             Console.WriteLine("======!");
             Thread.SpinWait(1000);
             return i.ToString();
         }
        );
    }
    private static void Main()
    {
        var dict = new ConcurrentDictionary<int, string>();
        Task.Factory.StartNew(LongGetOrAdd(dict, 1));
        Console.WriteLine();
        Console.WriteLine("press any key to exit . . .");
        Console.ReadKey();
    }
