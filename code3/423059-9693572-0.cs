    public static class Timer 
        {
            private static System.Timers.Timer _timer =  new System.Timers.Timer();
            public static void start(bool enabled, int interval)
            {
                _timer = new System.Timers.Timer(); 
                _timer.Elapsed += new ElapsedEventHandler(_timerElapsed);
                _timer.Enabled = enabled;
                _timer.Interval = interval;
            }
            static void _timerElapsed(object sender, ElapsedEventArgs e)
            {
                OnTimedEvent(sender, e);                
            }
        }
