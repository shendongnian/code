    public sealed class MultiThreadProtector : IDisposable
    {
        private object syncRoot;
        public MultiThreadProtector(object syncRoot)
        {
            this.syncRoot = syncRoot;
            
            if (!Monitor.TryEnter(syncRoot))
            {
                throw new Exception("Failure!");
            }
        }
        public void Dispose()
        {
            Monitor.Exit(this.syncRoot);
        }
    }
