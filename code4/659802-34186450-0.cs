    using System;
    using System.Numerics;
    public class PrimeChecker
    {
        public static void Main()
        {
        // Input
            Console.WriteLine("Enter number to check is it prime: ");
            BigInteger n = BigInteger.Parse(Console.ReadLine());
            bool prime = false;
    
        // Logic
            if ( n==0 || n==1)
            {
                Console.WriteLine(prime);
            }
            else if ( n==2 )
            {
                prime = true;
                Console.WriteLine(prime);
            }
            else if (n>2)
            {
                IsPrime(n, prime);
            }
        }
    
        // Method
        public static void IsPrime(BigInteger n, bool prime)
        {
            bool local = false;
            for (int i=2; i<=(BigInteger)Math.Sqrt((double)n); i++)
            {
                if (n % i == 0)
                {
                    local = true;
                    break;
                }
            }
            if (local)
                {
                    Console.WriteLine(prime);
                }
            else
            {
                prime = true;
                Console.WriteLine(prime);
            }
        }
    }
