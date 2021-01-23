    public class TimerWrapper : IGenericTimer
    {
        private readonly System.Timers.Timer timer;
        public event EventHandler<TimerElapsedEventArgs> Elapsed;
        public TimeSpan Interval
        {
            get
            {
                return this.timer.Interval;
            }
            set
            {
                this.timer.Interval = value;
            }
        }
        public TimerWrapper (TimeSpan interval)
        {
            this.timer = new System.Timers.Timer(interval.TotalMilliseconds) { Enabled = false };
            this.timer.Elapsed += this.WhenTimerElapsed;
        }
        private void WhenTimerElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            var handler = this.Elapsed;
            if (handler != null)
            {
                handler(this, new TimeElapsedEventArgs(elapsedEventArgs.SignalTime));
            }
        }
        public void StartTimer()
        {
            this.timer.Start();
        }
        public void StopTimer()
        {
            this.timer.Stop();
        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.timer.Elapsed -= this.WhenTimerElapsed;
                    this.timer.Dispose();
                }
              
                this.disposed = true;
            }
        }
    }
