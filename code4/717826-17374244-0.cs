    public static IEnumerable<BigInteger> Range(BigInteger from, BigInteger to)
    {
        for(BigInteger i = from; i < to; i++) yield return i;
    }
    
    usage:
        var bigs = Range(new BigInteger(10), new BigInteger(20));
