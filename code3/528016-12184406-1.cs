namespace C.D
{
    class B
    {
        private int a, b;
        public B()
        {
        }
        class A
        {
            public A() { }
            public B DoStuff()
            {
                B b = new B();
                b.a = 1; b.b = 2;
                return b;
            }
        }
    }
}
namespace C
{
    class E
    {
        static void Main(String[] args)
        {
            A a = new A();
            B b = a.DoStuff();
        }
    }
}
