    class StringType : IDifferentTypes
    {
        public String StringProperty { get; set; }
        public Object Value
        {
            get
            {
                // works with any type that can auto cast to `Object`
                return StringProperty;
            }
            set
            {
                // Optional
                if( typeof(string) != value.GetType() )
                {
                    throw new MyException();
                }
                // works for any nullable type
                StringProperty = value as string;
                // OR
                // throws an exception if conversion fails
                StringProperty = (string)value;
            }
        }
    }
