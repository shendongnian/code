    private static void ThreadMethod1()
    { 
        Thread.CurrentThread.IsBackground = true;
        Console.WriteLine("ThreadMethod1() waiting...");
        while (true)
        {
            waitHandle.WaitOne();
            Console.WriteLine("ThreadMethod1() continuing...");   
        }
    }
