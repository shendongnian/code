    public static class LinqExtensions
    {
        public static IEnumerable<T> SelectOdds<T>(this IEnumerable<T> enumerable)
        {
            bool odd = false;
            foreach (var item in enumerable)
            {
                if (odd)
                    yield return item;
                odd = !odd;
            }
        }
    }
