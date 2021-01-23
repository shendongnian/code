    static volatile object obj = new object();
    static void Main(string[] args)
    {
        ThreadStart start = () =>
        {
            ThreadTest();
        };
        var t = new Thread(() => start());
        t.Name = "t";
        t.Start();
        Thread.Sleep(3000);
        obj = null;
        // Why the Thread (t) continue here??
        Console.ReadKey();
    }
    private static void ThreadTest()
    {
        while (obj != null)
        {
            Console.WriteLine(Thread.CurrentThread.Name);
            Thread.Sleep(1000);
        }
    }
