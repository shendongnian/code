    static void SomeMethod()
    {
        Console.WriteLine("Thread ID = " + Thread.CurrentThread.ManagedThreadId);
    
        Console.WriteLine("performing an action...");
    }
    
    static void Main(string[] args)
    {
        int someValueInSeconds = 5;
    
        Console.WriteLine("Thread ID = " + Thread.CurrentThread.ManagedThreadId);
    
        Task.Delay(TimeSpan.FromSeconds(someValueInSeconds)).ContinueWith(t => SomeMethod());
    
        // Prevents the app from terminating before the task above completes
        Console.WriteLine("Countdown launched. Press a key to exit.");
        Console.ReadKey();
    }
