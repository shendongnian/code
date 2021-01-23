    public static class LinqEx
    {
        public static IEnumerable<T> ToIEnumerable<T>(this T singleItem)
        {
            yield return singleItem;
        }
    }
