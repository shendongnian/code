    public static class test
    {
        static void Main(string[] args)
        {
            Foo();
            Foo("test");
        }
    
        public static void Foo()
        {
            Console.WriteLine("No message supplied");
        }
    
        public static void Foo(string message)
        {
            Console.WriteLine(message);
        }
    }
