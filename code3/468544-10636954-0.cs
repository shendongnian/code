    class Program
    {
        public static void HelloWorld(string x = "Hi")
        {
            Console.WriteLine(x);
        }
        static void Main(string[] args)
        {
            HelloWorld();
            HelloWorld("Buyah");
        }
    }
