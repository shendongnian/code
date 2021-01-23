    // Func<int, T>: The int parameter will be the index of each element being created.
    public static IEnumerable<T> CreateSequence<T>(Func<int, T> elementCreator, int count)
    {
        if (elementCreator == null)
            throw new ArgumentNullException("elementCreator");
        for (int i = 0; i < count; ++i)
            yield return (elementCreator(i));
    }
