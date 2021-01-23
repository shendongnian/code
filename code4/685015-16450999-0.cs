    public static bool IsFoo<T>(IComparable<T> value, IComparable<T> other)
    {
        // ...
    }
    public static bool IsFoo<T>(T value, T other)
        where T : IComparable<T>
    {
        // ...
    }
