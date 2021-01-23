    public class ExampleService
    {
        private static readonly AutoResetEvent TimerLatch = new AutoResetEvent(false);
        private static readonly AutoResetEvent ShutdownLatch = new AutoResetEvent(false);
        private static readonly Timer MyTimer = new Timer(TimerTick);
        public void Start()
        {
            var t = new Thread(DoLoop);
            t.Start();
            MyTimer.Change(0, 500);
        }
        public void Stop()
        {
            ShutdownLatch.Set();
        }
        private static void TimerTick(object state)
        {
            TimerLatch.Set();
        }
        private static void DoLoop()
        {
            if (WaitHandle.WaitAny(new[] { TimerLatch, ShutdownLatch }) == 0)
            {
                // The timer ticked, do something timer related
            }
            else
            {
                // We are shutting down, do whatever cleanup you need
            }
        }
    }
