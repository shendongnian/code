    class Program
        {
            static void Main(string[] args)
            {
                
                if (foo() || bar())
                {
                    Console.WriteLine("Either Foo or Bar returned true");
                }
                Console.ReadKey();
            }
            public static bool foo()
            {
                Console.WriteLine("I am in Foo");
                return true;
            }
            public static bool bar()
            {
                Console.WriteLine("I am in Bar");
                return false;
            }
    
        }
