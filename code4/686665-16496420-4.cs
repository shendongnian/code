    class Program
    { 
        static void Main(string[] args) {
            Program p =new Program();
            p.Start();
            Console.WriteLine("done, press enter to finish");
            Console.ReadLine();
        }
        private readonly object SyncRoot = new object();
        ManualResetEvent mre = new ManualResetEvent(false);
        private void Start() {
            /*
             * The application will run the thread, which throws an exception
             * While Windows kicks in to deal with it and terminate the app, we still get 
             * a couple of "Failed to lock" messages
             * */
            Thread t1 = new Thread(SetLockAndTerminate);
            t1.Start();
            mre.WaitOne();
            for (int i = 0; i < 10; i++) {
                if (!Monitor.TryEnter(this.SyncRoot, 1000)) {
                    Console.WriteLine("Failed to lock");
                }
                else {
                    Console.WriteLine("lock succeeded");
                    return;
                }
            }
            Console.WriteLine("FINALLY NOT CALLED");
        }
        public int CauseAnOverflow(int i)
        {
            return CauseAnOverflow(i + 1);
        }
        public void SetLockAndTerminate() {
            Monitor.Enter(this.SyncRoot);
            Console.WriteLine("Entered");
            try {
                mre.Set();
                CauseAnOverflow(1); // Cause a stack overflow, prevents finally firing
            }
            finally {
                Console.WriteLine("Exiting");
                Monitor.Exit(this.SyncRoot);
            }
        }
    }
