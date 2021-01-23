    static volatile bool runThread = true;
    static void Main(string[] args)
    {
        var t = new Thread(ThreadTest);
        t.Start();
        Thread.Sleep(3000);
        runThread = false;
        Console.ReadKey();
    }
    private static void ThreadTest()
    {
        while (runThread)
        {
            Console.WriteLine(Thread.CurrentThread.Name);
            Thread.Sleep(1000);
        }
    }
