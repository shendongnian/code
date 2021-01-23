    interface IDifferentTypes
    {
        Object Value { get; set; }
    }
    class StringType : IDifferentTypes
    {
        string _value;
        public Object Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value as string;
            }
        }
    }
