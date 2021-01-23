    using System;
    using System.Numerics;
    
    class Test
    {
        static void Main()
        {
            string text = new string('1', 80);
            BigInteger number = BigInteger.Parse(text);
            Console.WriteLine(number);
        }
    }
