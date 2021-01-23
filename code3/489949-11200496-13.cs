    public sealed class MyEnumEmu
    {
        private static readonly string myValue = new MyEnumEmu("The text for MyValue");
        private static readonly string myOtherValue = new MyEnumEmu("Some other text");
        private static readonly string yetAnotherValue = new MyEnumEmu("Something else");
        public static MyEnumEmu MyValue
        {
            get
            {
                return myValue;
            }
        }
        public static MyEnumEmu MyOtherValue 
        {
            get
            {
                return myOtherValue;
            }
        }
        public static MyEnumEmu YetAnotherValue
        {
            get
            {
                return yetAnotherValue;
            }
        }
        private string _value;
        private MyEnumEmu(string value)
        {
            //Really, we are in control of the callers of this constructor...
            //... but, just for good measure:
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            else
            {
                _value = value;
            }
        }
        public string Value
        {
            get
            {
                return _value;
            }
        }
    }
