    using System;
    class Program
    {
        public enum E
        {
            A = 1,
            B = 1
        }
        static void Main(string[] args)
        {
            E value = E.B;
            Console.WriteLine(value == E.B);
            Console.WriteLine(value == E.A);
            Console.ReadKey();
        }
    }
