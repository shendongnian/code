    class Program
    {
        static void Main(string[] args)
        {
            B b = new B { b1 = 22222 };
            A a = b;
            Console.WriteLine(a.a1);
            Console.WriteLine(((B)a).b1);
        }
    }
            
