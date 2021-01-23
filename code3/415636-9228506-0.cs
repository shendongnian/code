    class AccurateTimer
    {
        public event EventHandler<EventArgs> Tick;
        public bool Running { get; private set; }
        public int Interval { get; private set; }
        public AccurateTimer(int interval_ = 1000)
        {
            Running = false;
            Interval = interval_;
        }
        public void Start()
        {
            Running = true;
            Thread thread = new Thread(Run);
            thread.Start();
        }
        public void Stop()
        {
            Running = false;
        }
        private void Run()
        {
            DateTime nextTick = DateTime.Now.AddMilliseconds(Interval);
            while (Running)
            {
                if (DateTime.Now > nextTick)
                {
                    nextTick = nextTick.AddMilliseconds(Interval);
                    OnTick(EventArgs.Empty);
                }
            }
        }
        protected void OnTick(EventArgs e)
        {
            EventHandler<EventArgs> copy = Tick;
            if (copy != null)
            {
                copy(this, e);
            }
        }
    }
