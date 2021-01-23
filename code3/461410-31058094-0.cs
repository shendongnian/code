    class Program
    {
        static void Main(string[] args)
        {
            Timer t = new Timer(TimerCallback, null,0,2000);
            Console.ReadKey();
        }
        static object timerLock = new object();
        static void TimerCallback(object state)
        {
            int tid = Thread.CurrentThread.ManagedThreadId;
            bool lockTaken = false;
            try
            {
                lockTaken = Monitor.TryEnter(timerLock);
                if (lockTaken)
                {
                    Console.WriteLine("[{0:D02}]: Task started", tid);
                    Thread.Sleep(3000); // Do the work 
                    Console.WriteLine("[{0:D02}]: Task finished", tid);
                }
                else
                {
                    Console.WriteLine("[{0:D02}]: Task is already running", tid);
                }
            }
            finally
            {
                if (lockTaken) Monitor.Exit(timerLock);
            }
        }
    }
