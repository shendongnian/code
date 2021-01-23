    public static class Extensions
    {
        public static Tuple<int, int> DistinctAndCount<T>(this IEnumerable<T> elements)
        {
            HashSet<T> hashSet = new HashSet<T>();
            int count = 0;
            foreach (var element in elements)
            {
                count++;
                hashSet.Add(element);
            }
            return new Tuple<int, int>(hashSet.Count, count);
        }
    }
