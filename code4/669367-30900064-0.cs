    class SetOp<T>
    {
        public T Value { get; private set; }
        public bool Include { get; private set; }
        public SetOp(T value, bool include)
        {
            Value = value;
            Include = include;
        }
    }
