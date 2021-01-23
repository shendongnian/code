    public class Hardware
    {
        System.Timers.Timer _timer;
        public event EventHandler Send;
        public Hardware()
        {
            _timer = new System.Timers.Timer();
            _timer.Interval = 1000;
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();
        }
        void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Send(this, new SendArgs(DateTime.Now.Ticks));
        }
        public class SendArgs : EventArgs
        {
            public long Id { get; private set; }
            public SendArgs(long id)
            {
                Id = id;
            }
        }
    }
