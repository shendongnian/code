    public static IQueryable<T> Include<T>(this IQueryable<T> sequence, params string[] includes) {
        var objectQuery = sequence as ObjectQuery<T>;
        if (objectQuery != null){
            foreach(item in includes){
                 objectQuery.Include(item);
            }
            return objectQuery;
        }
        return sequence;
    }
