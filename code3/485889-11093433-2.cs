    public static class IntExtensions
    {
        public static int? SomeCoolLinqMethod(this IEnumerable<int> ints)
        {
            int counter = ints.Count() > 0 ? ints.First() : -1;
            while (counter < int.MaxValue)
            {
                if (!ints.Contains(++counter)) return counter;
            }
            return null;
        }
    }
