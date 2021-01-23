    using System;
    
    class Program
    {
        static bool IsPrime(int n)
        {
            if (n % 2 == 0) return false;
            for (int i = 3; i <= Math.Sqrt(n); i += 2)
                if (n % i == 0) return false;
            return true;
        }
    
        static void Main()
        {
            long x = 600851475143;
            int? lastDivisor = null;
            for (int i = 3; i <= Math.Sqrt(x); i += 2)
                if (x % i == 0 && IsPrime(i)) lastDivisor = i;
            Console.WriteLine(lastDivisor);
        }
    }
