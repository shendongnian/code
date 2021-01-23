    public struct column<TType>
    {
        private TType _value;
        private column(TType value) : this()
        {
            _value = value;
        }
        private void Set(TType value)
        {
            // Implement your custom set-behavior...
        }
        private TType Get()
        {
            // Implement your custom get-behavior...
            return _value;
        }
        public override string ToString()
        {
            return _value.ToString();
        }
        public static implicit operator column<TType>(TType p)
        {
            column<TType> column = new column<TType>(p);
            column.Set(p);
            return column;
        }
        public static implicit operator TType(column<TType> p)
        {
            return p.Get();
        }
    }
