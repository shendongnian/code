    public static bool IsIncreasingMonotonicallyBy<T, TKey>(
        this IEnumerable<T> _this,
        Func<T, TKey> keySelector)
        where TKey : IComparable<TKey>
    {
        return _this.Select(keySelector).IsIncreasingMonotonically();
    }
