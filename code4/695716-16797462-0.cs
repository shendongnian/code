    struct MyStruct
    {
        private readonly int _value;
        public MyStruct(int val) { this._value = val; }
        public override bool Equals(object obj) { return false; }
        public override int GetHashCode() { return base.GetHashCode(); }
        public static bool operator ==(MyStruct a, MyStruct b) { return false; }
        public static bool operator !=(MyStruct a, MyStruct b) { return false; }
    }
