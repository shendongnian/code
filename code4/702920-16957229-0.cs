    public class ThreadPoolTimerSpy : IDisposable
    {
        private readonly ThreadPoolTimer _threadPoolTimer;
        private int _intervalElapsedCallCount;
        private readonly ManualResetEvent _resetEvent = new ManualResetEvent(false);
        public int NumberOfIntervals { get; set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public ThreadPoolTimerSpy(ThreadPoolTimer threadPoolTimer)
        {
            if (threadPoolTimer == null) throw new ArgumentNullException("threadPoolTimer");
            _threadPoolTimer = threadPoolTimer;
            _threadPoolTimer.IntervalElapsed += OnIntervalElapsed;
            NumberOfIntervals = 1;
        }
        public void Measure()
        {
            _intervalElapsedCallCount = 0;
            _resetEvent.Reset();
            StartTime = DateTime.Now;
            _threadPoolTimer.Start();
            
            _resetEvent.WaitOne();
        }
        private void OnIntervalElapsed(object sender, EventArgs arguments)
        {
            _intervalElapsedCallCount++;
            if (_intervalElapsedCallCount < NumberOfIntervals)
                return;
            _threadPoolTimer.Stop();
            EndTime = DateTime.Now;
            _resetEvent.Set();
        }
        public void Dispose()
        {
            _threadPoolTimer.Dispose();
            _resetEvent.Dispose();
        }
    }
