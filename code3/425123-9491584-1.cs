    class Test
    {
        static void Foo(int x)
        {
            Console.WriteLine("Foo(int x)");
        }
    
        static void Foo(double y)
        {
            Console.WriteLine("Foo(double y)");
        }
        
        static void Main()
        {
            Foo(10);
        }
    }
