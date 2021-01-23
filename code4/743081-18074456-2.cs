    class BooleanWrapper : IDisposable
    {
        private object _value; // boxed value
        public BooleanWrapper(out bool value)
        {
            value = true;
            _value = value;
        }
        public void Dispose()
        {
            _value = false;
        }
    }
