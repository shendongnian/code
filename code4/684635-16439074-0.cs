    class Wrapper
    {
        public dynamic theAorBorC;
        public Wrapper(A a){theAorBorC=a;}
        public Wrapper(B b){theAorBorC=b;}
        public Wrapper(C c){theAorBorC=c;}
        // or even...
        // public Wrapper(object anything){theAorBorC=anything;}
        public void CallFoo()
        {
            theAorBorC.Foo();
        }
    }
