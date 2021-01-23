    public class PrimeRange
    {
        public int Start;
        public int Snd;
    }
    List<PrimeRange> primes = new []
    {
        new PrimeRange{Start = 0, End = 1000},
        new PrimeRange{Start = 1001, End = 2000}
        // An so on
    };
    Parallel.ForEach(primes, x => CalculatePrimes(x, OnResult())));
