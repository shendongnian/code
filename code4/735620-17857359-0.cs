    static void Main(string[] args)
    {
        TaskManAsync().Wait();
    }
    static async Task TaskManAsync()
    {
        Task t1 = Task.Run(() => m1());
        Task t2 = Task.Run(() => m2());
        await Task.WhenAll(t1, t2);
        Console.WriteLine("Complete");
    }
    static void m1()
    {
        decimal result = 0;
        for (int n = 1; n < 100000000; n++)
        {
            result += n;
        }
        Console.WriteLine(result);
    }
    static void m2()
    {
        decimal result = 0;
        for (int n = 1; n < 100000000; n++)
        {
            result += n;
        }
        Console.WriteLine(result);
    }
