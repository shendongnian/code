    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            C c = new C();
            a.GetBeingSupportRate();
            b.GetBeingSupportRate();
            c.GetBeingSupportRate();
            
            Console.Read();
        }
        public class A
        {
            public const int beingSupportedRate = 0;
            public void GetBeingSupportRate()
            {
                Console.WriteLine(beingSupportedRate);
            }
        }
        public class B : A
        {
            public new const int beingSupportedRate = 1;
        }
        public class C : B
        {
        }
    }
