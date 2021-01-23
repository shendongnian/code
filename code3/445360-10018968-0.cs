    public static IEnumerable<T> ExceptWhere<T>(this IEnumerable<T> source, Predicate<T> predicate)
    {
        return source.Where(x=>!predicate(x));
    }
    //usage in above situation
    resultList = results.ExceptWhere(x=>x.Id == 2).ToList();
