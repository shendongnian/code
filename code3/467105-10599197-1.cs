    class A : C
    {
        private C GetC()
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
