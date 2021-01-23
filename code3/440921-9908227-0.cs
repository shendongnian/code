    interface MyInterface
    {
        Object MyProperty
        {
            get;
            set;
        }
    }
    class MyClass : MyInterface
    {
        Object MyInterface.MyProperty
        {
            get
            {
                return this.MyProperty;
            }
            set
            {
                if (value is MyType)
                    this.MyProperty = (MyType)value;
            }
        }
        public MyType MyProperty
        {
            get;
            set;
        }
    }
