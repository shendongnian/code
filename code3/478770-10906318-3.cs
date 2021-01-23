        public virtual void Close()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
