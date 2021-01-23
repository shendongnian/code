    static void Main(string[] args)
    {
        WriteOutput("Program Begin");
        // DoAsTask();
        DoAsAsync();
        WriteOutput("Program End");
        Console.ReadLine();
    }
    
    static void DoAsTask()
    {
        WriteOutput("1 - Starting");
        var t = Task.Factory.StartNew<int>(DoSomethingThatTakesTime);
        WriteOutput("2 - Task started");
        t.Wait();
        WriteOutput("3 - Task completed with result: " + t.Result);
    }
    
    static async Task DoAsAsync()
    {
        WriteOutput("1 - Starting");
        var t = Task.Factory.StartNew<int>(DoSomethingThatTakesTime);
        WriteOutput("2 - Task started");
        var result = await t;
        WriteOutput("3 - Task completed with result: " + result);
    }
    
    static int DoSomethingThatTakesTime()
    {
        WriteOutput("A - Started something");
        Thread.Sleep(1000);
        WriteOutput("B - Completed something");
        return 123;
    }
    
    static void WriteOutput(string message)
    {
        Console.WriteLine("[{0}] {1}", Thread.CurrentThread.ManagedThreadId, message);
    }
