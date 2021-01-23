    public static class ThreadSafeThing {
        private static UnsafeThing _thing = new UnsafeThing();
        private static readonly object _lock = new object();
        public static void getLock() {
            Monitor.Enter(_lock);
        }
        public static void releaseLock() {
            Monitor.Exit(_lock);
        }
        // this is your thread-safe version of Thing.DoSomething             
        public static bool DoSomething() {
            try {
                Monitor.Enter(_lock);
                return _thing.DoSomething();
            }
            finally {
                Monitor.Exit(_lock);
            }
        }
        // this is your thread-safe version of Thing.DoSomethingElse
        public static void DoSomethingElse() {
            try {
                Monitor.Enter(_lock);
                return _thing.DoSomethingElse();
            }
            finally {
                Monitor.Exit(_lock);
            }
        }
    }
