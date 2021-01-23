    private T[] Cast<T>(params object[] items)
    {
        if (!typeof(T).IsValueType)
        {
            throw new ArgumentException("Destined type must be Value Type");
        }
        return items.Cast<T>().ToArray();
    }
