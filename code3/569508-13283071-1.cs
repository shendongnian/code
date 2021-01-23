        static void Main(string[] args)
        {
            long number = 5;
            for (long i = 1; i < 600851475143; i++)
            {
                if (IsPrime(i))
                {
                    Console.WriteLine(i);
                    number = i;
                }
            }
        }
