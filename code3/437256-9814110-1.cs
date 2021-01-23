    static class LinqExtensions
    {
        public static IEnumerable<IList<T>> ChunkToList<T>(this IEnumerable<T> list, int size)
        {
            Debug.Assert(list.Count() % size == 0);
            int index = 0;
            while (index < list.Count())
            {
                yield return list.Skip(index).Take(size).ToList();
                index += size;
            }
        }
    }
