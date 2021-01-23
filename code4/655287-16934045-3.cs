    public static class CallerContext
    {
        [ThreadStatic]
        private static object _state;
        public static object State
        {
            get { return _state; }
            set { _state = value; }
        }
    }
