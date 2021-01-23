        public class SomeClass
        {
            private MyClass _myClass;
            public MyClass MyClass
            {
                get { return _myClass ?? (_myClass = new MyClass()); }
                set { _myClass = value; }
            }
        }
        public class SomeClass
        {
            private readonly MyClass _myClass = new MyClass();
            public MyClass MyClass
            {
                get { return _myClass; }
            }
        }
