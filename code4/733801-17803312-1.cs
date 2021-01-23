    class A<T>
    {
        public A(T b)
        {}
    }
    class B<T> : A<T>
    {
       public B(T b)
       : base(b)
        {}
    }
    class C<T> : B<T>
    {
        public C(T b)
        : base(b)
        { }
    }
