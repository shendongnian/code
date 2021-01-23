    class sealed Foo : IDisposable
    {
        readonly Bar _bar;
        bool _disposed;
        ...
        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                _bar.Changed -= BarChanged;
            }
        }
        ...
    }
