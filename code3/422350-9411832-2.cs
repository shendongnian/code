    int[] GeneratePrimes(int n)
    {
       List<int> primes = new List<int>();
       
       while (primes.Length < n)
       {
          if (IsPrime(i))
          {
             primes.Add(i);
          }
       }
       return primes.ToArray();
    }
