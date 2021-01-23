    class Program
    {
        private static ManualResetEvent mre = new ManualResetEvent(false);
        static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(SleepAndSet));
            t.Start();
            Console.WriteLine("Waiting");
            mre.WaitOne();
            Console.WriteLine("Resuming");
        }
        public static void SleepAndSet()
        {
            Thread.Sleep(2000);
            mre.Set();
        }
    }
