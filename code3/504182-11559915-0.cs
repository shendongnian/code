    class A 
    {
        public B b;
    
        public A()
        {
            this.b = new B(new C(this));
        }
    }
    class B
    {
        public C c;
        public B(C c)
        {
            this.c = c;       
        }
    }
    class C
    {
        public A a;
        public C(A a)
        {
            this.a = a;
        }
    }
