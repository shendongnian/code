    struct Inner
    {
        public int A;
    }
    struct Outer
    {
        public Inner I;
        public int B;
    }
    Outer o = new Outer();
    o.I = new Inner();
