    public static class EnumerableYieldExtension
    {
        public static IEnumerable<T> Yield<T>(this T item)
        {
            if (item == null)
                yield break;
            yield return item;
        }
    }
