            for (;;)
            {
                Console.Write("Accept number: ");
                int n = int.Parse(Console.ReadLine());
                if (IsPrime(n))
                {
                    Console.WriteLine("{0} is a prime number",n);
                }
                else
                {
                    Console.WriteLine("{0} is not a prime number",n);
                }
            }
