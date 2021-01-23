    public class ThrowObjectDisposedImplicitly : IDisposable
    {
        private MemoryStream stream;
        public ThrowObjectDisposedImplicitly()
        {
            this.stream = new MemoryStream();
        }
        public void DoSomething()
        {
            // This will throw ObjectDisposedException as necessary
            this.stream.ReadByte();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.stream.Dispose();
            }
        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
