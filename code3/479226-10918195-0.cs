    class DerivedClass2 : BaseClass2
    {
        public DerivedClass1A objA
        {
            get
            {
                return (DerivedClass1A)base.list[0];
            }
            set
            {
                base.list[0] = value;
            }
        }
        public DerivedClass1B objB
        {
            get
            {
                return (DerivedClass1B)base.list[1];
            }
            set
            {
                base.list[1] = value;
            }
        }
    }
