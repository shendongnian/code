    public class TimeElapsedEventArgs : EventArgs
    {
        public DateTime SignalTime { get; private set; }
        public TimeElapsedEventArgs() : this(DateTime.Now)
        {
        }
        public TimeElapsedEventArgs(DateTime signalTime)
        {
            this.SignalTime = signalTime;
        }
    }
    public interface IGenericTimer : IDisposable
    {
        double IntervalInMilliseconds { get; set; }
        event EventHandler<TimerElapsedEventArgs> Elapsed;
        void StartTimer();
        void StopTimer();
    }
