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
                // works for any nullable type
                StringProperty = value as string;
            }
        }
    }
