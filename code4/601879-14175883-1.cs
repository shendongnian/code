    public interface IIntger
    {
        void Set(int iValue);
        int Get();
    }
    
    public class MyWrapper
    {
        MyClass _Instance { get; set; }
        public IInteger Integer { get; private set; }
    
        private class _Integer : IInteger
        {
            MyWrapper _Parent { get; set; }
    
            public void Set(int iValue) { _Parent._Instance.IntegerSet(iValue); }
            public int Get() { return _Parent._Instance.IntegerGet(); }
        }
    
        public MyWrapper()
        {
            _Instance = new MyClass();
            Integer = new _Integer(this);
        }
    }
