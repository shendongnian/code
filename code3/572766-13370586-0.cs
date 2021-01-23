     static void Main(string[] args)
            {
                Test1("just a little test string.");     // warm up
                GC.Collect();  // compact Heap
                GC.WaitForPendingFinalizers(); // and wait for the finalizer queue to empty
                Stopwatch timer = new Stopwatch();
                timer.Start();
                for (int i = 0; i < 10000; i++)
                {
                    Test1("just a little test string.");
                }
                timer.Stop();
                Console.WriteLine(timer.Elapsed);
            }
