    public class WrappedField<T>
    {
        public class Internals
        {
            public T Value;
        }
    
        private readonly Internals _internals = new Internals();
        private readonly Func<Internals, T> _get;
        private readonly Action<Internals, T> _set;
    
        public T Value
        {
            get { return _get(_internals); }
            set { _set(_internals, value); }
        }
    
        public WrappedField(Func<Internals, T> get, Action<Internals, T> set)
        {
            _get = get;
            _set = set;            
        }
    
        public WrappedField(Func<Internals, T> get, Action<Internals, T> set, T initialValue)
            : this(get, set)
        {
            _set(_internals, initialValue);
        }
    }
