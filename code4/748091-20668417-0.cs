    public static class Paginate
    {
        public static IEnumerable<T> Enumerable<T>(int records, int iPage, IEnumerable<T> input) where T : class { return input.Skip(records * iPage).Take(records); }
    // My internal OCD hates this dup >.o
        public static IQueryable <T> Queryable <T>(int records, int iPage, IQueryable <T> input) where T : class { return input.Skip(records * iPage).Take(records); }
    }
