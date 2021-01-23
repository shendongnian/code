    /// Wrapper for properties that notify their change by means of an observable sequence
    class ObservableProperty<T>
    {
        T val;
        ISubject<T> sub = new Subject<T>();
        public T Value
        {
            get { return val; }
            set
            {
                val = value;
                sub.OnNext(value);
            }
        }
        public IObservable<T> Observable
        {
            get { return sub; }
        }
    }
