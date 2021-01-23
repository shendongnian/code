    public static class IntExtensions
    {
        public static int? SomeCoolLinqMethod(this IEnumerable<int> ints)
        {
            int val = ints.First();
            while (val < int.MaxValue)
            {
                if (!ints.Contains(++val)) return val;
            }
            return null;
        }
    }
