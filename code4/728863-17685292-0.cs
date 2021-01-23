    public static class BatchingExtensions
    {
        public static IEnumerable<List<T>> InBatches<T>(this IEnumerable<T> items, int length)
        {
            var list = new List<T>(length);
            foreach (var item in items)
            {
                list.Add(item);
                if (list.Count == length)
                {
                    yield return list;
                    list = new List<T>(length);
                }
            }
            if (list.Any())
                yield return list;
        }
    }
