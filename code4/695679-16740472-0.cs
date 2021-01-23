    namespace TestingEXtensions
    {
        using CustomExtensions;
        class Program
        {
            static void Main(string[] args)
            {
                var value = 0;
                Console.WriteLine(value.ToString()); //Test output
                value = value.GetNext(); 
                Console.WriteLine(value.ToString()); // see that it incremented
                Console.ReadLine();
            }
        }
    }
    namespace CustomExtensions 
    {
        public static class IntExtensions
        {
            public static int GetNext(this int i)
            {
                return i + 1;
            }
        }
    }
