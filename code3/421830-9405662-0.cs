        static void Main(string[] args)
        {
            int itemCount = 1000;
            Stopwatch stopwatch = new Stopwatch(); 
            long initialMemoryFootPrint = GC.GetTotalMemory(true);
            stopwatch.Start();
            for (int i = 0; i < itemCount; i++)
            {
                int iCopy = i;  // You should not use 'i' directly in the thread start as it creates a closure over a changing value which is not thread safe. You should create a copy that will be used for that specific variable.
                Thread thread = new Thread(() =>
                {
                    // lets simulate something that takes a while
                    int k = 0;
                    while (true)
                    {
                        if (k++ > 100000)
                            break;
                    }
                    if ((iCopy + 1) % 200 == 0) // By the way, what does your sendMessage(list[0]['1']); mean? what is this '1'? if it is i you are not thread safe.
                        Console.WriteLine(iCopy + " - Time elapsed: (ms)" + stopwatch.ElapsedMilliseconds);
                });
                thread.Name = "SID" + iCopy; // you can also use i here. 
                thread.Start();
            }
            Console.ReadKey();
            Console.WriteLine(GC.GetTotalMemory(false) - initialMemoryFootPrint);
            Console.ReadKey();
        }
