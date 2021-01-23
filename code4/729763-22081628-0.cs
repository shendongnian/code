    private static void HandleMessage(string message)
    {
        DoWork(message);
    }
    private static async Task DoWork(string message)
    {
        await Task.Delay(2000); // instead of thread.Sleep
        // do some work...
        Console.WriteLine(message);
    }
