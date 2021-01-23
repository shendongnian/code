    public static class EM
    {
        public static int[] FindAllIndexof<T>(this IEnumerable<T> values, T[] val)
        {
            List<int> index = new List<int>();
            for (int j = 0; j < val.Length; j++)
                index.Add(values.Count(x => object.Equals(x, val[j])));
            return index.ToArray();
        }
    }
