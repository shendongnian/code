    class C
    {
        public int Method1() { return 1; }
        public int Method2() { return 2; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            C myC = new C();
            Func<C, int> ptrToMember1 = (C c) => { return c.Method1(); };
            int i = Method(myC, ptrToMember1 );
        }
        static int Method(C c, Func<C, int> method)
        {
            return method(c);
        }
    }
