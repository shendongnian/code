    public static IEnumerable<long> Range(long start, long count)
    {
        for (long i = 0; i < count; i++)
        {
            yield return start++;
        }
    }
