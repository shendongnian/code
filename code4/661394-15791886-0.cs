    public struct Value27
    {
        private byte val;
        private bool isDef;
        private Value27() { }
        private Value27(byte value)
        {
           val = value % 27;
           isDef = true;
        }
        public static Value27 Make(byte value)
        { return new Value27(value); }
        public bool HasValue { get { return isDef; } }
        public byte Value { get { return val; } }
        public static Value27 operator +(Value27 curValue)
        { return Make(curValue.Value + 1); }
        public static Value27 operator -(Value27 curValue)
        { return Make(curValue.Value + 26); }
        public static implicit operator Value27(byte bValue)
        { return Make(bValue); }
        public static implicit operator byte(Value27 value)
        { return value.Value; }
    }
       
 
