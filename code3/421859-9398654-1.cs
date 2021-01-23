    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press enter");
            Console.ReadLine();
            Boop.SayHi();
            Boop.SayHi();
            Console.ReadLine();
        }
    }
    static class Boop
    {
        static Boop()
        {
            Console.WriteLine("Hi incoming ...");
        }
        public static void SayHi()
        {
            Console.WriteLine("Hi there!");
        }
    }
