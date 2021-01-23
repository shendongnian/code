    public static class SessionTimer
    {
        static _timer = new System.Timers.Timer();
        static List<Action> _delegates = new List<Action>();
        static Dictionary<string, Action> _delegateLookup = new Dictionary<string, Action>();
        static object _lockObj = new Object();
        static SessionTimer()
        {
            _timer.Interval = 120000;
            _timer.Elapsed
            _timer.Start();
        }
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            foreach (var d in _delegates)
            {
                d();
            }
        }
        public static Enlist(HttpSessionState s, Action d)
        {
            lock (_lockObj)
            {
                _delegates.Add(d);
                _delegateLookup.Add(s.SessionID, d);
            }
        }
        public static Delist(HttpSessionState s)
        {
            lock (_lockObj)
            {
                _delegates.Remove(_delegateLookup[s.SessionID]);
                _delegateLookup.Remove(s.SessionID);
            }
        }
    }
