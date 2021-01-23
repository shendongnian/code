    class B
    {
        static void Main(string[] args)
        {
            A a = new A();
            C c = a.GetC();
            C c2 = C(); //Non-invocable member 'C' cannot be used like a method
        }
    }
    class A : C
    {
        public new C GetC()
        {
            C c = C.GetC();
            return c;
        }
    }
    class C
    {
        protected C()
        {
        }
        protected static C GetC()
        {
            return new C();
        }
    }
