    public static class Extensions
    {
        public static List<T[]> SplitEven<T>(this T[] array, int count)
        {
            long remainder;
            long divCount = Math.DivRem(array.Count(), count, out remainder);
            int ajustedCount = (int)(count + (remainder / divCount));
            return Enumerable.Range(0, remainder != 0 ? (int)divCount + 1 : (int)divCount)
                .Select(g => array.Skip(g * ajustedCount).Take(ajustedCount).ToArray()).ToList();
        }
    }
