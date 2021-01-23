    public static class SystemTime
    {
        private static Func<DateTime> now = () => DateTime.Now;
        public static DateTime Now
        {
            get { return now(); }
        }
        public static void Set(DateTime dt)
        {
            now = () => dt;
        }
        public static void MoveForward(TimeSpan ts)
        {
            var dt = now().Add(ts);
            Set(dt);
        }
        public static void Reset()
        {
            now = () => DateTime.Now;
        }
    }
