    static class VFactory
    {
        public static V<T> Create<T>(T value)
        {
            return new V<T>(() => value, true);
        }
        public static V<T> Create<T>(Func<T> getter)
        {
            return new V<T>(getter, false);
        }
    }
    class V<T>
    {
        public readonly Func<T> Get;
        public readonly bool IsConstant;
        internal V(Func<T> get, bool isConstant)
        {
            Get = get;
            IsConstant = isConstant;
        }
    }
    void DumpValue<T>(V<T> v)
    {
        //...
    }
    void Main()
    {
        DumpValue(VFactory.Create("test"));
        DumpValue(VFactory.Create(() => "test"));
    }
