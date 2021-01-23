    public class A
    {
        public bool HasChanged { get; set; }
        object _Value;
        public object Value
        {
            get
            {
                return _Value;
            }
            set
            {
                HasChanged = value != _Value;
                _Value = value;
            }
        }
        public A(object _value)
        {
            _Value = _value;
            HasChanged = false;
        }
    }
