    class Program
    {
        public delegate void printer();
    
        public static void MethodA()
        {
            Console.WriteLine("Hello");
        }
    
        public static void MethodB()
        {
            Console.WriteLine("World");
        }
        static void Main(string[] args)
        {
            bool x = true;
    
            printer del = delegate 
            {
                if (x)
                {
                    MethodA();
                }
                else
                {
                    MethodB();
                }
            };
    
            del();
            Console.ReadKey();
        }
    }
