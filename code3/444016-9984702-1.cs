    static class Program
    {
        static void Main(string[] args)
        {
            int myNumber = 5;
            if (myNumber.EqualToAny(1, 2, 3, 4, 5))
                Console.WriteLine("Hello, World");
        }
    }
