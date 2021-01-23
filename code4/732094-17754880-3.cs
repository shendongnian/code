    class MyEnumerableExtensions
    {
        //For a source containing N delimiters, returns exactly N+1 lists
        public static IEnumerable<List<T>> SplitOn(
            this IEnumerable<T> source,
            T delimiter)
        {
            var list = new List<T>();
            foreach (var item in source)
            {
                if (delimiter.Equals(item))
                {
                    yield return list;
                    list = new List<T>();
                }
                else
                {
                    list.Add(item);
                }
            }
            yield return list;
        }
    }
