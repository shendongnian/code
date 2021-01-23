    public static class ListExtener
    {
        public static List<int> FindAllIndexes<T>(this List<T> source, T value)
        {
            return source.Select((item, index) => new { Item = item, Index = index })
                            .Where(v => v.Item.Equals(value))
                            .Select(v => v.Index)
                            .ToList();
        }
    }
