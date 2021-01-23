    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                BigInteger number = BigInteger.Pow(Int64.MaxValue, 300000);
                Console.WriteLine(number);
            }
        }
    }
