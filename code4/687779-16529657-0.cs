    public static IEnumerable<TResult> Generate<TResult>(TResult initial, Func<TResult, TResult> generator)
    {
        if (generator == null) throw new ArgumentNullException("generator");
        return GenerateImpl(initial, generator);
    }
    private static IEnumerable<TResult> GenerateImpl<TResult>(TResult initial, Func<TResult, TResult> generator)
    {
        TResult current = initial;
        while (true)
        {
            yield return current;
            current = generator(current);
        }
    }
