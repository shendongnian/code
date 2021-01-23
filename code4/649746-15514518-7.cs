    public static class Extensions
    {
        public static List<T[]> Split<T>(this T[] array, int count)
        {
            return Enumerable.Range(0, (int)Math.Ceiling(array.Count() / (double)count))
                .Select(g => array.Skip(g * count).Take(count).ToArray()).ToList();
        }
        
        public static List<T[]> SplitEven<T>(this T[] array, int count)
        {
            long remainder;
            long divCount = Math.DivRem(array.Count(), count, out remainder);
            remainder = count + (remainder / divCount);
            return Enumerable.Range(0, (int)divCount)
                .Select(g => array.Skip(g * (int)remainder).Take((int)remainder).ToArray()).ToList();
        }
    }
