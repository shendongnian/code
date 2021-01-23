    static volatile bool stop = false;
    
    static void Main(string[] args)
    {    
        new Thread(() =>
        {
            Thread.Sleep(1000);
            stop = true;
            Console.WriteLine("Set \"stop\" to true.");
    
        }).Start();
    
        Console.WriteLine("Entering loop.");
    
        while (!stop)
        {
        }
    
        Console.WriteLine("Done.");
    }
