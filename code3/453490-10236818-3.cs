    class Bar { }
    interface I
    {
        int Foo(Bar bar);
    }
    class C
    {
        public static R M<A, R>(A a, Func<I, Func<A, R>> f) 
        { 
            return default(R); 
        }
    }
