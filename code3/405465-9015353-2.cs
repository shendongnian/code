    public class ThrowObjectDisposedExplicity : IDisposable
    {
        private MemoryStream stream;
        public ThrowObjectDisposedExplicity()
        {
            this.stream = new MemoryStream();
        }
        public void DoSomething()
        {
            if (this.stream == null)
            {
                throw new ObjectDisposedException(null);
            }
            this.stream.ReadByte();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.stream != null)
                {
                    this.stream.Dispose();
                    this.stream = null;
                }
            }
        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
