    public static class RandomExt
    {
        public static T Choice<T>(this Random random, IEnumerable<T> sequence)
        {
            var list = sequence as IList<T> ?? sequence.ToList();
            return list[random.Next(list.Count)];
        }
    }
