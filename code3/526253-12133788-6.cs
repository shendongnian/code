    class sealed Foo : IDisposable
    {
        Bar _bar;
        ...
        public void Dispose()
        {
            if (_bar != null)
            {
                _bar.Changed -= BarChanged;
                _bar = null;
            }
        }
        ...
    }
