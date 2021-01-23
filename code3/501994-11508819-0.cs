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
            a.EventHappened += new EventHandler(this.HandleEvent);
        }
        public void Dispose()
        {
            // You may wish to unsubscribe from events here
            disposed = true;
        }
    
        public void HandleEvent(object sender, EventArgs args)
        {
            if (disposed)
            {
                throw new ObjectDisposedException();
            }
        }
     }
