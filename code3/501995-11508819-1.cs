    class A
    {
       public EventHandler EventHappened;
    }
    
    class B : IDisposable
    {
        A _a;
        private bool disposed;
    
        public B(A a)
        {
            _a = a;
            a.EventHappened += this.HandleEvent;
        }
        public void Dispose(bool disposing)
        {
            // As an aside - if disposing is false then we are being called during 
            // finalization and so cannot safely reference _a as it may have already 
            // been GCd
            // In this situation we dont to remove the handler anyway as its about
            // to be cleaned up by the GC anyway
            if (disposing)
            {
                // You may wish to unsubscribe from events here
                _a.EventHappened -= this.HandleEvent;
                disposed = true;
            }
        }
    
        public void HandleEvent(object sender, EventArgs args)
        {
            if (disposed)
            {
                throw new ObjectDisposedException();
            }
        }
     }
