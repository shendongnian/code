    public static class EnumerableExt
    {
        public static bool AllPredicatesTrueOverall<T>(this IEnumerable<T> self, params Predicate<T>[] predicates)
        {
            bool[] results = new bool[predicates.Length];
            foreach (var item in self)
            {
                for (int i = 0; i < predicates.Length; ++i)
                    if (predicates[i](item))
                        results[i] = true;
                if (results.All(state => state))
                    return true;
            }
            return false;
        }
