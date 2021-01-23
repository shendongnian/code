    static System.Timers.Timer timer;
    static void Main(string[] args)
    {
        var cancelSource = new CancellationTokenSource();
        timer = new System.Timers.Timer(200);
        
        timer.Elapsed += new SomeTimerConsumer(cancelSource.Token).timer_Elapsed;
        timer.Start();
        // Let it run for a while
        Thread.Sleep(5000);
        // Stop "immediately"
        cancelSource.Cancel(); // Tell running events to finish ASAP
        lock (timer)
            timer.Dispose();
               
    }
    class SomeTimerConsumer
    {
        private CancellationToken cancelTimer;
        public SomeTimerConsumer(CancellationToken cancelTimer)
        {
            this.cancelTimer = cancelTimer;
        }
        public void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            lock (timer)
            {
                // Do some potentially long operation, that respects cancellation requests
                if (cancelTimer.IsCancellationRequested)
                    return;
                // More stuff here
            }
        }
    }
