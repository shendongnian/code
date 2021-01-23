    static void Main(string[] args)
    {
        for (int i = 0; i < 100; i++)
        {
            Task t = new Task(doWork, i);
            t.Start();
        }
        Console.ReadLine();
    }
    
    static void doWork(object i)
    {
        Console.WriteLine(i + ": started");
        Thread.SpinWait(20000000); // It depends on what doWork actually does whether SpinWait or Sleep is the most appropriate test
        //Thread.Sleep(1000);
        Console.WriteLine(i + " done");
    }
