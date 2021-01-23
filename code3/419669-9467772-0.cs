    public class MyDisposeableWrapper
    {
        public MyDisposeable MyDisposeable
        {
            get;
            set;
        }
        public bool NeedsDisposed
        {
            get;
            set;
        }
        public MyDisposeableWrapper(MyDisposeable myDisposeable, bool needsDisposed)
        {
            MyDisposeable = myDisposeable;
            NeedsDisposed = needsDisposed;
        }
    }
