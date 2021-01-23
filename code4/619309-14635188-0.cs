    static List<long> Sieve(long To)
    {
        To /= 2;
    
        List<long> Primes = new List<long>();
    
        if (To > 0)
            Primes.Add(2);
    
        Parallel.For(1L, To, a =>
        {
            long f = 2 * a + 1;
            Primes.Add(f);
        });
    
        Primes.Sort();
    
        return Primes;
    }
