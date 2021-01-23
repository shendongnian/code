    class Program
    {
        // global success indicator
        private const int NotDone = 0;
        private const int AllDone = 1;
        private static int _allDone = NotDone;
        private static int _forwardsCount = 0;    // counters to simulate a "find"
        private static int _backwardsCount = 0;   // counters to simulate a "find"
        static void Main(string[] args) {
            var searchItem = "foo";
            Thread t1 = new Thread(() => DoSearchWithBarrier(SearchForwards, searchItem));
            Thread t2 = new Thread(() => DoSearchWithBarrier(SearchBackwards, searchItem));
            t1.Start(); t2.Start();
            t1.Join(); t2.Join();
            Console.WriteLine("all done");
        }
        private static void DoSearchWithBarrier(Func<string, bool> searchMethod, string searchItem) {
            while (!searchMethod(searchItem)) {
                // after one or a few iterations, if this thread is still going
                //   see if another thread has set _allDone to AllDone
                if (Interlocked.CompareExchange(ref _allDone, NotDone, NotDone) == AllDone) {
                    return; // if they did, then exit
                }
            }
            Interlocked.Exchange(ref _allDone, AllDone);
        }
        public static bool SearchForwards(string item) {
            //  return true if we "found it", false if not
            return (Interlocked.Increment(ref _forwardsCount) == 10);
        }
        public static bool SearchBackwards(string item) {
            //  return true if we "found it", false if not
            return (Interlocked.Increment(ref _backwardsCount) == 20); // make this less than 10 to find it backwards first
        }
    }
