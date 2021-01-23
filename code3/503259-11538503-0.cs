    class Base
    {
        public Base() : this(1)
        {
        }
        public Base(int param)
        {
            paramVal = param;
        }
        private int paramVal;
    }
    class Derived : Base
    {
        public Derived() : base(2)
        {   
        }
    }
