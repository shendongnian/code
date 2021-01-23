    public static class Extensions
    {
        public static List<T[]> Split<T>(this T[] array, int count)
        {
            return Enumerable.Range(0, (int)Math.Ceiling(array.Count() / (double)count))
                .Select(g => array.Skip(g * count).Take(count).ToArray()).ToList();
        }
    }
