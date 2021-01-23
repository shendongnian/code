    public partial class MyClass
    {
        public int Property
        {
            get { return _properties.Property; }
            set { _properties.Property = value; }
        }
        public void Stuff()
        {
            // Can't get to _backingField...
        }
    }
    public partial class MyClass
    {
        private readonly Properties _properties = new Properties();
        private class Properties
        {
            private int _backingField;
            public int Property
            {
                get { return _backingField; }
                set
                {
                    // perform checks
                    _backingField = value;
                }
            }
        }
    }
