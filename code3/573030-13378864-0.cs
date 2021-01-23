    Parallel.ForEach(BigIntSequence(1,10), (i) => Console.WriteLine(i));
    public IEnumerable<BigInteger> BigIntSequence(BigInteger min,BigInteger max)
    {
        BigInteger bi = min;
        while (bi<max)
        {
            yield return bi;
            bi += 1;     
        }
    }
