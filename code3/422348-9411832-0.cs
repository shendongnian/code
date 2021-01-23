    int[] GeneratePrimes(int n)
    {
       List<int> primes = new List<int>();
       for (int i=1; i<=n i++)
       {
          if (IsPrime(i))
          {
             primes.Add(i);
          }
       }
       return primes.ToArray();
    }
