    Console.WriteLine("starting task...");
    Task.Run(() =>
    {
        try
        {
            mre.Set();
            Console.WriteLine("sleeping...");
            Thread.Sleep(9999);
            Console.WriteLine("woke up");
        }
        finally
        {
            Console.WriteLine("finally");
        }
    });
    
    Console.WriteLine("waiting for task to get inside the try clause...");
    mre.WaitOne();
    Console.WriteLine("Task entered try clause, exiting...");
    Environment.Exit(0);
