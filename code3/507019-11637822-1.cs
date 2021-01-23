    namespace ConsoleApplication1
    {
        public class sample
        {
            public static void Main(string[] args)
            {
                Console.WriteLine("TEST");
                Console.ReadKey();
            }
        }
    }
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                sample.Main(new string[] { });
            }
        }
    }
