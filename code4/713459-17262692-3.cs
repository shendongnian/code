    class Program {
        ...
        private static int _forwardsCount = 0;    // counters to simulate a "find"
        private static int _backwardsCount = 0;   // counters to simulate a "find"
        static void Main(string[] args) {
            Barrier barrier = new Barrier(numThreads, 
                b => Console.WriteLine("Completed search iteration {0}", b.CurrentPhaseNumber));
            var searchItem = "foo";
            Thread t1 = new Thread(() => DoSearchWithBarrier(SearchForwards, searchItem, barrier));
            Thread t2 = new Thread(() => DoSearchWithBarrier(SearchBackwards, searchItem, barrier));
            t1.Start(); Console.WriteLine("Started t1");
            t2.Start(); Console.WriteLine("Started t2");
            t1.Join(); Console.WriteLine("t1 done");
            t2.Join(); Console.WriteLine("t2 done");
            Console.WriteLine("all done");
        }
        private static void DoSearchWithBarrier(Func<string, bool> searchMethod, string searchItem, Barrier barrier) {
            while (!searchMethod(searchItem)) {
                // while we haven't found it, wait for the other thread to catch up
                barrier.SignalAndWait(); // check for the other thread AFTER the barrier
                if (Interlocked.CompareExchange(ref _allDone, NotDone, NotDone) == AllDone) {
                    return;
                }
            }
            // set success signal on this thread BEFORE the barrier
            Interlocked.Exchange(ref _allDone, AllDone);
            // wait for the other thread, and then exit (and it will too)
            barrier.SignalAndWait();
        }
        ...
    }
