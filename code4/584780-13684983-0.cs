    class Foo
    {
        public bool MyPropertySelected
        {
            get;
            set;
        }
        public readonly int MyProperty
        {
            get 
            {
                return MyPropertySelected ? MyProperty1 : MyProperty2;
            }
        }
        private int MyProperty1
        {
            get;
            set;
        }
        private int MyProperty2
        {
            get;
            set;
        }
    }
