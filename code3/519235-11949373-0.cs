    public class ThreadSafeThing
    {
        private UnsafeThing _thing = new UnsafeThing();
        private object _syncRoot = new object();
        public void DoSomething()   // this is your thread-safe version of Thing.DoSomething
        {
            lock (_syncRoot)
            {
                _thing.DoSomething();
            }
        }
    }
