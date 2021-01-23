    public static class IQueryOverExtension
    {
        public static IQueryOver<T, T> CombinedWhere<T>(this IQueryOver<T, T> source, params Expression<Func<T, bool>>[] predicates)
        {
            var result =  source.Where(predicates.First());
            var i = 0;
            foreach (var predicate in predicates)
            {
                if (i == 0) continue;
                result = result.And(predicate);
                i++;
            }
            return result;
        }
    }
