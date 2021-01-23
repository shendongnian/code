    interface iA
    {
        public int a { get; set; }
    }
    interface iB
    {
        public int b { get; set; }
    }
    interface iAB : iA, iB
    {
    }
    class MyClass : iA, iB
    {
        public int b { get; set; }
        public int a { get; set; }
    }
    static class MyClassExtender
    {
        static public int Foo(this iAB ab)
        {
            int c = ab.a + ab.b;
            ab.a = c;
            return c;
        }
        static public int FooA(this iA a)
        {
            int c = ab.a + 1;
            ab.a = c;
            return c;
        }
        static public int FooB(this iB b)
        {
            int c = ab.b + 1;
            ab.a = c;
            return c;
        }
    }
