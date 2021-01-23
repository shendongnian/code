    public class PerformanceTester : IDisposable
    {
        private Stopwatch _stopwatch = new Stopwatch();
    
        public PerformanceTester()
        {
            _stopwatch.Start();
        }    
   
        public void Dispose()
        {
            _stopwatch.Stop();            
        }
    
        public TimeSpan Results
        {
            get { return _stopwatch.Elapsed; }
        }
    }
