    class A : ICloneable
    {
        private readonly int _member;
        public A(int member)
        {
            _member = member;
        }
        public A(A a)
        {
            _member = a._member;
        }
        public object Clone()
        {
            return new A(this);
        }
    }
