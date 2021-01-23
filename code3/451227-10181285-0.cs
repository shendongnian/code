    public class Foo
    {
        private static readonly object _locker = new object();
    
        public void FooMethod(object stateInfo)
        {
            // Don't let threads back up; just get out
            if (!Monitor.TryEnter(_locker)) { return; }
    
            try
            {
                // Logic here
            }
            finally
            {
                Monitor.Exit(_locker);
            }
        }
    }
