    static void SomeMethod()
    {
        Console.WriteLine("performing an action...");
    }
    
    static void Main(string[] args)
    {
        int someValueInSeconds = 5;
    
        Task.Delay(TimeSpan.FromSeconds(someValueInSeconds)).ContinueWith(t => SomeMethod());
    
        // Prevents the app from terminating before the task above completes
        Console.WriteLine("Countdown launched. Press a key to exit.");
        Console.ReadKey();
    }
