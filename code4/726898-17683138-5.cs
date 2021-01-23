    public static class EnumerableExtensions
    {
        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> source, int groups)
        {
            var listedSource = source.ToList();
            int extra;
            int groupSize = Math.DivRem(listedSource.Count(), groups, out extra);
            while (listedSource.Any())
            {
                int newSize = groupSize;
                if (extra > 0)
                {
                    newSize++;
                    extra--;
                }
                yield return listedSource.Take(newSize);
                listedSource = listedSource.Skip(newSize).ToList();
            }
        }
    }
