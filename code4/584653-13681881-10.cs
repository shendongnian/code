    public class PerformanceTester : IDisposable
    {
        private Stopwatch _stopwatch = new Stopwatch();
        private Action<TimeSpan> _callback;
    
        public PerformanceTester()
        {
            _stopwatch.Start();
        }
    
        public PerformanceTester(Action<TimeSpan> callback) : this()
        {
            _callback = callback;            
        }
    
        public static PerformanceTester Start(Action<TimeSpan> callback)
        {
            return new PerformanceTester(callback);
        }
    
        public void Dispose()
        {
            _stopwatch.Stop();
            if (_callback != null)
                _callback(Result);
        }
    
        public TimeSpan Result
        {
            get { return _stopwatch.Elapsed; }
        }
    }
