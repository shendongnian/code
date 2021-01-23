    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Where<T>(
            this IEnumerable<T> self,
            Func<T,bool> predicate,
            out Func<int> getFailureCount)
        {
            if (self == null) throw new ArgumentNullException("self");
            if (predicate == null) throw new ArgumentNullException("predicate");
    
            int failures = 0;
            
            getFailureCount = () => failures;
                    
            return self.Where(i =>
                {
                    bool res = predicate(i);
                    if (!res)
                    {
                        ++failures;
                    }
                    return res;
                });
        }
    }
