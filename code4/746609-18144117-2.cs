    class SimpleCountdown
    {
        private readonly ManualResetEvent mre = new ManualResetEvent(false);
        private int remainingPulses;
        public int RemainingPulses
        {
            get
            {
                // Note that this value could be not "correct"
                // You would need to do a 
                // Thread.VolatileRead(ref this.remainingPulses);
                return this.remainingPulses;
            }
        }
        public SimpleCountdown(int pulses)
        {
            this.remainingPulses = pulses;
        }
        public void Wait()
        {
            this.mre.WaitOne();
        }
        public bool Pulse()
        {
            if (Interlocked.Decrement(ref this.remainingPulses) == 0)
            {
                mre.Set();
                return true;
            }
            return false;
        }
    }
    public static SimpleCountdown sc = new SimpleCountdown(10);
    public static void Waiter()
    {
        sc.Wait();
        Console.WriteLine("Finished waiting");
    }
    public static void Main()
    {
        new Thread(Waiter).Start();
        while (true)
        {
            // Press 10 keys
            Console.ReadKey();
            sc.Pulse();
        }
    }
