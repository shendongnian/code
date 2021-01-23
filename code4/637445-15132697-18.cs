    class Foo
    {
        private string _value;
        private object _tag; // Unused in this example
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
        public object Tag
        {
            get { return _tag; }
            set { _value = _tag; }
        }
    }
