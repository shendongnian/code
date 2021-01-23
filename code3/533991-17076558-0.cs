    private static async Task<int> Sleep(int ms)
    {
        Console.WriteLine("Sleeping for " + ms);
        var task = Task.Run(() => Thread.Sleep(ms));
        await task;
        Console.WriteLine("Sleeping for " + ms + "END");
        return ms;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Starting");
        var task1 = Sleep(2000);
        var task2 = Sleep(1000);
        int totalSlept = task1.Result +task2.Result;
        Console.WriteLine("Slept for " + totalSlept + " ms");
        Console.ReadKey();
    }
