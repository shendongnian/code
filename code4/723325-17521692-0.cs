    internal class Program
        {
            private static void Main(string[] args)
            {
                List<Thread> threads = new List<Thread>();
                ThreadTest tt = new ThreadTest();
                for (int i = 0; i < 10; i++)
                {
                    // alter the varialbe shared
                    lock (tt.thisLock)
                    {
                        Thread t = new Thread(() => tt.DoAction(string.Format("Thread-{0}", i)));
                        threads.Add(t);
                        t.Start();
                    }
                }
                // wait after each thread
                foreach (Thread item in threads)
                {
                    item.Join();
                }
                tt.ReadList();
    
                Console.ReadKey();
            }
        }
    
        internal class ThreadTest
        {
            public Object thisLock = new Object();
            protected IList<string> myList = new List<string>();
    
            public void DoAction(string info)
            {
                myList.Add(info);
            }
    
            public void ReadList()
            {
                foreach (string item in myList)
                {
                    Console.WriteLine(item);
                }
            }
        }
