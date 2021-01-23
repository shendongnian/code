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
           return _thing.DoSomething();
        }
        // this is your thread-safe version of Thing.DoSomethingElse
        public static void DoSomethingElse() {
            return _thing.DoSomethingElse();
        }
    }
