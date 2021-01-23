    static void Main(string[] args)
    {
        Console.WriteLine("Program Begin");
        // DoAsTask();
        DoAsAsync();
        Console.WriteLine("Program End");
        Console.ReadLine();
    }
    static void DoAsTask()
    {
        Console.WriteLine("1 - Starting");
        var t = Task.Factory.StartNew<int>(DoSomethingThatTakesTime);
        Console.WriteLine("2 - Task started");
        t.Wait();
        Console.WriteLine("3 - Task completed with result: " + t.Result);
    }
    
    static async void DoAsAsync()
    {
        Console.WriteLine("1 - Starting");
        var t = Task.Factory.StartNew<int>(DoSomethingThatTakesTime);
        Console.WriteLine("2 - Task started");
        var result = await t;
        Console.WriteLine("3 - Task completed with result: " + result);
    }
    
    static int DoSomethingThatTakesTime()
    {
        Console.WriteLine("A - Started something");
        Thread.Sleep(1000);
        Console.WriteLine("B - Completed something");
        return 123;
    }
