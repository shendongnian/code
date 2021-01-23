    public struct FakeBool
    {
        private readonly bool val;
        private FakeBool(bool val) { this.val = val; }
        public static implicit operator bool(FakeBool f) { return f.val; }
        public static implicit operator FakeBool(bool f) { return new FakeBool(f); }
    }
    public MyClass(FakeBool someFlag = default(FakeBool)) { ... }
    public MyClass(T defaultValue, FakeBool someFlag = default(FakeBool)) { ... }
    var b2 = new MyClass<bool>(true);            // calls two-argument constructor
    var b1 = new MyClass<bool>(someFlag: true); // calls one-argument constructor
