    using System;
    public class Stopwatch
    {
        private System.Diagnostics.Stopwatch _stopwatch = null;
        TimeSpan _offset;
        public Stopwatch()
        {
            _stopwatch = new System.Diagnostics.Stopwatch();
        }
        public void Start()
        {
            _stopwatch.Start();
        }
        public void Stop()
        {
            _stopwatch.Stop();
        }
        public void Restart()
        {
            _stopwatch.Restart();
        }
        public void Reset()
        {
            _stopwatch.Reset();
        }
    
        public void SetOffset(TimeSpan offsetElapsedTimeSpan)
        {
            _offset = offsetElapsedTimeSpan;
        }
        public TimeSpan Elapsed
        {
            get{ return _stopwatch.Elapsed + _offset; }
            set{ _offset = value; }
        }
        public long ElapsedMilliseconds
        {
            get { return _stopwatch.ElapsedMilliseconds + _offset.Milliseconds; }
        }
        public long ElapsedTicks
        {
            get { return _stopwatch.ElapsedTicks + _offset.Ticks; }
        }
    }
