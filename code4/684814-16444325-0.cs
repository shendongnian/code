    using System;
    
    class A
    {
        public A(int a, int b, int c)
        {
        }
    }
    
    class B : A
    {
        public B(int a, int b, int c) : base(a, b, c)
        {
        }
    
        public void Blah(int something)
        {
            Console.WriteLine("B.Blah");
        }
    }
    
    
    
    class Test
    {
        static void Main()
        {
            B b = new B(1, 2, 3);
            b.Blah(10);
        }
    }
