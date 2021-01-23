    static class Extensions
    {
        public static IEnumerable<T> MergeWith<T>(this IEnumerable<T> source, IEnumerable<T> other) where T : ICanMerge
        {
            var otherItems = other.ToDictionary(x => x.Key);
            foreach (var item in source)
            {
                yield return (T)item.MergeWith(otherItems[item.Key]);
            }
        }
        public static string AsNullIfEmpty(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return null;
            else
                return s;
        }
    }
