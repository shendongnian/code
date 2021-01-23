    public static class MyOps
    {
        public static IEnumerable<T> FindDuplicates<T>(this IEnumerable<T> input)
        {
            var hashSet1 = new HashSet<T>();
            var hashSet2 = new HashSet<T>();
            foreach (var item in input)
                if (!hashSet1.Add(item)) // note the negation
                    if (hashSet2.Add(item)) // note NO negation
                        yield return item;
        }
    }
    var firstList = new[] { 1, 1, 3 };
    var result1 = firstList.FindDuplicates();
