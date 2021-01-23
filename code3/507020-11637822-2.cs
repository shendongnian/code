    namespace ConsoleApplication1
    {
        public class sample
        {
            public static void Main()
            {
                Console.WriteLine("My Output...");
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
                sample.Main();
            }
        }
    }
