    public static class IEnumerableStringExtensions
    {
        public static StringCollection ToStringCollection(this IEnumerable<string> strings)
        {
            var stringCollection = new StringCollection();
            foreach (string s in strings)
                stringCollection.Add(s);
            return stringCollection;
        }
    }
