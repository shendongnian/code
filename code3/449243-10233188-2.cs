    static void Main(string[] args)
    {
        //We just need a single-thread for this test.
        Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(2);
        System.Threading.Thread.BeginThreadAffinity();
        Console.Write("Enter test number (1|2): ");
        string input = Console.ReadLine();
        //perform the action just a few times to jit the code.
        ListArrayLoop warmup = new ListArrayLoop(10, 10);
        Console.WriteLine("Performing warmup...");
        Test(warmup.ListSum);
        Test(warmup.ArraySum);
        Console.WriteLine("Warmup complete...");
        Console.WriteLine();
        ListArrayLoop test = new ListArrayLoop(10000, 10000);
        if (input == "1")
        {
            Test(test.ListSum);
            Test(test.ListSum);
            Test(test.ArraySum);
            Test(test.ListSum);
        }
        else
        {
            Test(test.ArraySum);
            Test(test.ArraySum);
            Test(test.ListSum);
            Test(test.ArraySum);
        }
    }
    private static void Test(Action test)
    {
        long totalElapsed = 0;
        for (int counter = 10; counter > 0; counter--)
        {
            try
            {
                var sw = Stopwatch.StartNew();
                test();
                totalElapsed += sw.ElapsedMilliseconds;
            }
            finally { }
            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            //cooldown
            for (int i = 0; i < 100; i++)
                System.Threading.Thread.Sleep(0);
        }
        Console.WriteLine("{0} averages {1}", test.Method.Name, totalElapsed / 10);
    }
