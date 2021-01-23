    public class HardwareMonitor
    {
        private readonly object _locker = new object();
        private readonly TimeSpan _monitoringInterval;
        private readonly Thread _thread;
        private readonly ManualResetEvent _stoppingEvent = new ManualResetEvent(false);
        private readonly ManualResetEvent _stoppedEvent = new ManualResetEvent(false);
        public HardwareMonitor(TimeSpan monitoringInterval)
        {
            _monitoringInterval = monitoringInterval;
            _thread = new Thread(ThreadFunc)
                {
                    IsBackground = true
                };
        }
        public void Start()
        {
            lock (_locker)
            {
                if (!_stoppedEvent.WaitOne(0))
                    throw new InvalidOperationException("Already running");
                _stoppingEvent.Reset();
                _stoppedEvent.Reset();
                _thread.Start();
            }
        }
        public void Stop()
        {
            lock (_locker)
            {
                _stoppingEvent.Set();
            }
            _stoppedEvent.WaitOne();
        }
        private void ThreadFunc()
        {
            try
            {
                while (true)
                {
                    // Wait for time interval or cancellation event.
                    if (_stoppingEvent.WaitOne(_monitoringInterval))
                        break;
                    // Monitoring...
                    // NOTE: update UI elements using Invoke()/BeginInvoke() if required.
                }
            }
            finally
            {
                _stoppedEvent.Set();
            }
        }
    }
