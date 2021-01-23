    public struct Optional<T>
    {
        private bool hasValue;
        private T value;
        public T Value
        {
            get
            {
                if (hasValue)
                    return value;
                else
                    throw new InvalidOperationException();
            }
        }
        public Optional(T value)
        {
            this.value = value;
            hasValue = true;
        }
    }
