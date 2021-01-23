    public static class MoreLinqWrapper
    {
        public static IEnumerable<TResult> MlZip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
        {
            return MoreLinq.Zip(first, second, resultSelector);
        }
    }
