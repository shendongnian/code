    public struct Value27
    {
        private readonly int val;
        private readonly bool isDef;
        private Value27(int value)
        {
           while (value < 0) value += 27;
           val = value % 27;
           isDef = true;
        }
        public static Value27 Make(int value)
        { return new Value27(value); }
        public bool HasValue { get { return isDef; } }
        public int Value { get { return val; } }
        public static Value27 operator +(Value27 curValue)
        { return Make(curValue.Value + 1); }
        public static Value27 operator -(Value27 curValue)
        { return Make(curValue.Value + 26); }
        public static implicit operator Value27(int bValue)
        { return Make(bValue); }
        public static implicit operator int (Value27 value)
        { return value.Value; }
    }
       
 
