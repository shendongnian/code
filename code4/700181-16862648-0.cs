    using System;
    class Program
    {
        public static void Main(string[] args)
        {
            DateTime? x = new Program();
            Console.ReadKey(true);
        }
        public static implicit operator DateTime(Program x)
        {
            return new DateTime();
        }
    }
