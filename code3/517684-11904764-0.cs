    static class Program
    {
        static void Main(string[] args)
        {
            2.HelloWorld();
        }
        public static void HelloWorld(this int value)
        {
            Console.WriteLine(value);
        }
    }
