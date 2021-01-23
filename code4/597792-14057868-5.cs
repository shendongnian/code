    public static IEnumerable<int> RandomSequence(int minInclusive, int maxExclusive)
    {
        Random rng = new Random();
        while (true)
        {
            yield return rng.Next(minInclusive, maxExclusive);
        }
    }
