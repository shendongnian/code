    using System;
    using System.Numerics;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main()
            {
                int factorial = Convert.ToInt32(Console.ReadLine());
    
                var result = CalculateFactorial(factorial);
    
                Console.WriteLine(result);
                Console.ReadLine();
            }
    
            private static BigInteger CalculateFactorial(long value)
            {
                BigInteger result = new BigInteger(1);
                for (int i = 1; i <= value; i++)
                {
                    result *= i;
                }
                return result;
            }
        }
    }
