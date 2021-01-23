    public static IEnumerable<BigInteger> Range(BigInteger from, BigInteger to)
    {
        for(BigInteger i = from; i < to; i++) yield return i;
    }
        
    public static class Extensions
    {
    	public static BigInteger RandomElement(this IEnumerable<BigInteger> enumerable, Random rand)
    	{
    		int index = rand.Next(0, enumerable.Count());
    		return enumerable.ElementAt(index);
    	}
    }
