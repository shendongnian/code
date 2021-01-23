    public class ListenerWaiting
    {
        public ListenerWaiting(int waitingTimeSeconds)
        {
            _waitSeconds = waitingTimeSeconds;
        }
        private int _waitSeconds;
        private System.Timers.Timer _timer;
        private Listener _listener;
        public event EventHandler<string> ListenerDone;
        public void Listen(int listeningPeriodSeconds)
        {
            _listener = new Listener(listeningPeriodSeconds * 1000);
            _listener.ListenerCompleted += ListenerListenerCompleted;
            _timer = new System.Timers.Timer(_waitSeconds * 1000) {Enabled = true};
            _timer.Elapsed += TimerElapsed;
        }
        void ListenerListenerCompleted(object sender, string e)
        {
            StopTimer();
            StopListener();
            if (ListenerDone != null)
                ListenerDone(this, "Waiting success! Message was: " + e);
        }
        void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            StopTimer();
            StopListener();
            if (ListenerDone != null)
                ListenerDone(this, "Waited longer than set, aborted waiting...");
        }
        private void StopTimer()
        {
            _timer.Stop();
            _timer.Elapsed -= TimerElapsed;
            _timer = null;
        }
        private void StopListener()
        {
            _listener.ListenerCompleted -= ListenerListenerCompleted;
            _listener = null;
        }
    }
    public class Listener
    {
        private System.Timers.Timer _timer;
        private string _listeningPeriodSeconds;
        public event EventHandler<string> ListenerCompleted;
        public Listener(int listeningPeriodSeconds)
        {
            _listeningPeriodSeconds = listeningPeriodSeconds.ToString();
            _timer = new System.Timers.Timer(listeningPeriodSeconds) { Enabled = true };
            _timer.Elapsed += TimerElapsed;
        }
        private void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _timer.Elapsed -= TimerElapsed;
            _timer = null;
            if (ListenerCompleted != null)
                ListenerCompleted(this, _listeningPeriodSeconds);
        }
        
    }
