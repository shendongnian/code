    public class MyClass
    {
        public string Name
        {
            get { return _name;  }
            set { _name = value; }
        }
        public int IID
        {
            get { return _iid; }
            set { if ((64 > value) && (value >= 0)) _iid = value; }
        }
        private string _name;
        private int    _iid;
    }
    public class MyClassCollection : CollectionBase
    {
        // See the article for code for the overrides (for CollectionBase) and implementation (for ICustomTypeDescriptor)
    }
