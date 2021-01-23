    public static class MyOps
    {
        public static IEnumerable<T> FindDuplicates<T>(this IEnumerable<T> input)
        {
            var hashSet = new HashSet<T>();
            foreach (var item in input)
                if (!hashSet.Add(item))
                    yield return item;
        }
    }
    var firstList = new[] { 1, 1, 3 };
    var result1 = firstList.FindDuplicates();
