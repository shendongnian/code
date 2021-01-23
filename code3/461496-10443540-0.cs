    public static class EM
    {
        public static int[] FindAllIndexof<T>(this IEnumerable<T> values, T val)
        {
            return values.Select((b,i) => b.Equals(val) ? i : -1).Where(i != -1).ToArray();
        }
    }
