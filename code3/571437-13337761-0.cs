    public static class StaticTimer
    {
        public delegate void Time(DateTime time);
        public static event Time Tick = delegate { };
        static StaticTimer()
        {
            DispatcherTimer myDispatcherTimer = new DispatcherTimer();
            myDispatcherTimer.Interval = new TimeSpan(0,0,1);
            myDispatcherTimer.Tick += (s,e) => Tick(DateTime.Now);
            myDispatcherTimer.Start();
        }
    }
