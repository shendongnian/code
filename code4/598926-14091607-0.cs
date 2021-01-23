        public static object Do(Action action, TimeSpan delay, int interval = Timeout.Infinite)
        {
            var t = new Timer(new TimerCallback(At.ExecuteDelayedAction), action, Convert.ToInt32(delay.TotalMilliseconds), interval);
            return t;
        }
