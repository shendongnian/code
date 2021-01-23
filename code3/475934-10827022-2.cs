    public static class MyEnumerableExtensions
    {
        public static IEnumerable<T[]> Splice<T>(this IEnumerable<T> source, int size)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source can't be null.");
            }
            if (size == 0)
            {
                throw new ArgumentOutOfRangeException("Splice size can't be 0.");
            }
            List<T> result = new List<T>(size);
            foreach (T x in source)
            {
                result.Add(x);
                if (result.Count == size)
                {
                    yield return result.ToArray();
                    result = new List<T>(size);
                }
            }
        }
    }
