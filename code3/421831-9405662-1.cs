        static void Main(string[] args)
        {
            int itemCount = 1000;
            Stopwatch stopwatch = new Stopwatch(); 
            long initialMemoryFootPrint = GC.GetTotalMemory(true);
            stopwatch.Start();
            for (int i = 0; i < itemCount; i++)
            {
                int iCopy = i; // You should not use 'i' directly in the thread start as it creates a closure over a changing value which is not thread safe. You should create a copy that will be used for that specific variable.
                ThreadPool.QueueUserWorkItem((w) =>
                {
                    // lets simulate something that takes a while
                    int k = 0;
                    while (true)
                    {
                        if (k++ > 100000)
                            break;
                    }
                    if ((iCopy + 1) % 200 == 0) 
                        Console.WriteLine(iCopy + " - Time elapsed: (ms)" + stopwatch.ElapsedMilliseconds);
                });
            }
            Console.ReadKey();
            Console.WriteLine("Memory usage: " + (GC.GetTotalMemory(false) - initialMemoryFootPrint));
            Console.ReadKey();
        }
