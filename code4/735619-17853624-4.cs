    async static void TaskMan()
    {
        Task t1 = Task.Run((Action)m1);
        Task t2 = Task.Run((Action)m2);
        await Task.WhenAll(t1, t2);
        Console.WriteLine("Compete");
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
