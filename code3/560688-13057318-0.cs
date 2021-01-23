    class Number
    {
        public int Value { get; set; }
    
        public Number(int initialValue)
        {
            Value = initialValue;
        }
    
        public static implicit operator Number(int initialValue)
        {
            return new Number(initialValue);
        }
    }
