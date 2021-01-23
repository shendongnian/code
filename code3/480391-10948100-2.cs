    public sealed class Lazy<T> where T : class
    {
        private readonly object _syncRoot = new object();
        private readonly Func<T> _factory;
        private T _value;
    	
        public Lazy(Func<T> factory)
        {
            if (factory == null) throw new ArgumentNullException("factory");
    
            _factory = factory;
        }
    
        public T Value
        {
            get
            {
                if (_value == null)
                {
                    lock (_syncRoot)
                    {
                        if (_value == null)
                        {
                            _value = _factory();
                        }
                    }
                }
                return _value;
            }
        }
    
        public override string ToString()
        {
            return _value == null ? "Not created" : _value.ToString();
        }
    }
