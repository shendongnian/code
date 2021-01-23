    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var b = FooFactory() as bar;
            }
    
            static private foo FooFactory()
            {
                return new foo();
            }
        }
    
        class foo {}
    
        class bar : foo {}
    }
