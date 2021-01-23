    using System;
    class Program
    {
        delegate bool MyFilter(int x);
        bool IsOdd(int x)
        {
            return x % 2 == 1;
        }
        static void Main()
        {
            MyFilter f = new Program().IsOdd;
            Console.WriteLine(f(5));
        }
    }
