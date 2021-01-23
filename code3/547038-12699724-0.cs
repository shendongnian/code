    public static class EnumerableExtensions
        {
            public static T FirstOrDefaultExcludingDeletes<T>(this IEnumerable<T> source, Func<T, bool> predicate)
            {
                return source.Where(args => args != IsDeleted).FirstOrDefault(predicate);
            }
        }
    
