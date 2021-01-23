    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                tester t = tester.x;
                t.testenums();
                Console.ReadKey();
            }
    
           
        }
    
        public static class ext
        {
            public static void testenums(this tester x)
            {
                Console.WriteLine(x.ToString());
            }
        }
    
        public enum tester
        {
            x,
            y
        }
    }
