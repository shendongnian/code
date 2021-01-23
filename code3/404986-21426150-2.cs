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
    public delegate void TimerElapsedEventHandler(object sender, TimeElapsedEventArgs args);
    public interface IGenericTimer : IDisposable
    {
        double IntervalInMilliseconds { get; set; }
        event TimerElapsedEventHandler Elapsed;
        void StartTimer();
        void StopTimer();
    }
