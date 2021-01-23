    public class MyLock : IDisposable
    {
        private object _toLock;
    
        public MyLock(object toLock)
        {
            _toLock = toLock;
            Monitor.Enter(_toLock);
        }
    
        public virtual void Dispose()
        {
            Monitor.Exit(_toLock);
        }
    }
