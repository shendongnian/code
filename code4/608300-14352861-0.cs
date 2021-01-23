    interface Maybe<T> {
        bool HasValue {get;}
        T Value {get;}
    }
    class Nothing<T> : Maybe<T> {
        public bool HasValue { get { return false; } }
        public T Value { get { throw new Exception(); } }
        public static const Nothing<T> Instance = new Nothing<T>();
    }
    class Just<T> : Maybe<T> {
        private T _value;
        public bool HasValue { get { return true; } }
        public T Value { get { return _value; } }
        public Just(T val) {
            _value = val;
        }
    }
