    List<int> sievePrimes = simpleSieve(maxSquareRoot);
    // simpleSieve is a standard SoE returning a list of primes not exceeding its argument
    var sieve = new System.Collections.BitArray(max - min + 1);
    int minSquareRoot = (int)Math.Sqrt(min);
    foreach(int p in sievePrimes)
    {
        int num = p > minSquareRoot ? p*p : ((min + p - 1)/p)*p;
        num -= min;
        for(; num <= max-min; num += p)
        {
            sieve[num] =true;
        }
    }
