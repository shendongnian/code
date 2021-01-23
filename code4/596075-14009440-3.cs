    class Program
    {
        static void Main(string[] args)
        {
            Foo();
        }
        public static void Foo(int i = 5)
        {
            Console.WriteLine("hi"   +i);
        }
    }
