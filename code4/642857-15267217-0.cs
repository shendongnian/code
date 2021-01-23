    public static class Extensions
    {
        public static bool AddRange<T>(this HashSet<T> @this, IEnumerable<T> items)
        {
            bool allAdded = true;
            foreach (T item in items)
            {
                added |= @this.Add(item);
            }
            return allAdded;
        }
    }
