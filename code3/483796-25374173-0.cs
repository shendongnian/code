    public static class EnumerableExtentions
    {
        public static IEnumerable<IEnumerable<T>> Chunks<T>(this IEnumerable<T> items, int   size)
        {
            return
                items.Select((member, index) => new { Index = index, Value = member })
                    .GroupBy(item => (int)item.Index / size)
                    .Select(chunk => chunk.Select(item => item.Value));
        }
    }
