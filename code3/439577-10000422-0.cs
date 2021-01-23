        class MyBase
        {
            // Define each child class as a new MyType enum
            public abstract MyType Type { get; }
        }
        class MyChild : MyBase
        {
            public override MyType Type
            {
                get { return MyType.Child1; }
            }
        }
