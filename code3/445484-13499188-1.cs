    class BaseClass
    {
        private string _myProperty;
        public string MyProperty
        {
            get { return _myProperty; }
            set
            {
                _nestedClass.MyNestedProperty = value;
                _myProperty = value;
            }
        }
        private NestedClass_ _nestedClass = new NestedClass_();
        private class NestedClass_
        {
            public string MyNestedProperty { get; set; }
        }
        public string MyNestedProperty
        {
            get { return _nestedClass.MyNestedProperty; }
            set
            {
                MyProperty = value;
                _nestedClass.MyNestedProperty = value;
            }
        }
    }
