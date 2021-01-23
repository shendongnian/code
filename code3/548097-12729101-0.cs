    public static class TimeProvider
    {
        static TimeProvider()
        {
            CurrentTimeProvider = () => DateTime.Now;
        }
        public static Func<DateTime> CurrentTimeProvider { get; set; }
        public static DateTime Now { get { return _CurrentTimeProvider(); } }
    }
