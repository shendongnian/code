    public static IEnumerable<long getPyramic(long maxValue)
    {
      return Enumerable.Range(0, maxValue)
      .Concat(Enumerable.Range(0, maxValue).Select(num => maxValue - num));
    }
