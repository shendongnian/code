    public static class SingletonAccessor
    {
        private static SomeClass _instance;
        private static object _lock = new Object();
        public static SomeClass Singleton
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new SomeClass();
                    }
                    return _instance;
                }
            }
        }
        public static void Recycle()
        {
            lock (_lock)
            {
                if (_instance != null)
                {
                    // Do any cleanup, perhaps call .Dispose if it's needed
                    _instance = null;
                }
            }
        }
    }
