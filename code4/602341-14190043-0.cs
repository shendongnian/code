    class Foo
    {
        Boolean _booleanValue;
        public bool BooleanValue
        {
            get { return _booleanValue; }
            set
            {
                _booleanValue = value;
                if (ValueChanged != null) ValueChanged(value);
            }
        }
        public event ValueChangedEventHandler ValueChanged;
    }
    delegate void ValueChangedEventHandler(bool value);
