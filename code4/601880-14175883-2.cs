    public class MyWrapper
    {
        public IInteger Integer { get; private set; }
    
        private class _Integer : IInteger
        {
            MyClass _Instance { get; set; }
            public _Integer(MyClass myClass) { _Instance = myClass; }
            public void Set(int iValue) { _Instance.IntegerSet(iValue); }
            public int Get() { return _Instance.IntegerGet(); }
        }
    
        public MyWrapper(MyClass instance)
        {
            Integer = new _Integer(instance);
        }
    }
