    public class Class1
    {
         // Use this to syncrhonize threads
        public static object SyncRoot = new object();
         // First "turn" goes to thread 1
        public static int threadInControl = 1;
        public static void thread1()
        {
            lock(SyncRoot)
            {
                Console.WriteLine("1");
                GiveTurnTo(2); // Let thread 2 have a turn
                WaitTurn(1);   // Wait for turn to be given to thread 1
                Console.WriteLine("t2 has printed 1, so we now print 2");
                GiveTurnTo(2); // Let thread 2 have a turn
                WaitTurn(1);   // Wait for turn to be given to thread 1
                Console.WriteLine("t2 has printed 2, so we now print 3");
                GiveTurnTo(2); // Let thread 2 have a turn
            }
        }
        public static void thread2()
        {
            lock(SyncRoot)
            {
                WaitTurn(2);   // Wait for turn to be given to thread 2
                Console.WriteLine("t1 has printed 1, so we now print 1");
                GiveTurnTo(1); // Let thread 1 have a turn
                WaitTurn(2);   // Wait for turn to be given to thread 2
                Console.WriteLine("t1 has printed 2, so we now print 2");
                GiveTurnTo(1); // Let thread 1 have a turn
                WaitTurn(2);   // Wait for turn to be given to thread 2
                Console.WriteLine("t1 has printed 3, so we now print 3");
                GiveTurnTo(1); // Let thread 1 have a turn
            }
        }
        // Wait for turn to use SyncRoot object
        public static void WaitTurn(int threadNum)
        {
            while (threadInControl != threadNum)
            {
                Monitor.Wait(SyncRoot);
            }
        }
        // Pass turn over to other thread
        public static void GiveTurnTo(int threadNum)
        {
            threadInControl = threadNum;
            Monitor.Pulse(SyncRoot);
        }
        public static void  void Main()
        {
            Thread t1 = new Thread(new ThreadStart(() => Class1.thread1()));
            Thread t2 = new Thread(new ThreadStart(() => Class1.thread2()));
            t1.Start();
            t2.Start();
            t2.Join();
            t1.Join();
        }
    }
