    using System;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                float f = 1.2999f;
                Console.WriteLine(f);
                Decimal d = Convert.ToDecimal(f);
                Console.WriteLine(d);
            }
        }
    }
