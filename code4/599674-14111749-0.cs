    bool isPrime = true;
            List<ulong> primes = new List<ulong>();
            ulong nCheck, nCounted;
            nCounted = 0;
            nCheck = 3;
            primes.Add(2);
            for (; ; )
            {
                isPrime = true;
                foreach (ulong nModulo in primes)
                {
                    if (((nCheck / 2) + 1) <= nModulo)
                    { break; }
                    if (nCheck % nModulo == 0)
                    { isPrime = false; }
                }
                if (isPrime == true)
                {
                    Console.WriteLine("New prime found: " + (nCheck) + ", prime number " + (++nCounted) + ".");
                    primes.Add(nCheck);
                }
                nCheck++;
                nCheck++;
            }
