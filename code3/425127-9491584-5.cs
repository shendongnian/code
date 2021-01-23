    class Test
    {
        static void Foo(int x)
        {
            Console.WriteLine("Foo(int x)");
        }
        
        static void Foo(string y)
        {
            Console.WriteLine("Foo(string y)");
        }
        
        static void Main()
        {
            Foo("text");
        }
    }
