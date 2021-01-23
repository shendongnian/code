    public static Task<IEnumerable<T>> Concat<T>(Task<IEnumerable<T>> first
            , Task<IEnumerable<T>> second)
    {
        return Task.Factory.ContinueWhenAll(new[] { first, second }, _ =>
        {
            return first.Result.Concat(second.Result);
        });
    }
