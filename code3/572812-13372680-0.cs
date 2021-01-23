    class Foo : IDisposable
    {
        public event EventHandler SomethingHappened;
        // ... normal IDisposable implementation details left out
        protected virtual void Dispose(bool Disposing)
        {
            if (Disposing)
            {
                SomethingHappened = null;
            }
        }
    }
