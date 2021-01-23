    public struct SurelyNotNull<T>
    {
        private readonly T _value;
    
        public SurelyNotNull(T value)
        {
            if(value == null)
                throw new ArgumentNullException("value");
            _value = value;
        }
    
        public T Value
        {
            get { return _value; }
        }
    }
