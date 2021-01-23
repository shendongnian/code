    //There is only one implementation of ToList()
    public List<T> ToList<T>(this IEnumerable<T> e) 
    {
        var list = new List<T>();
        var enumerator = e.GetEnumerator();
        while (enumerator.MoveNext())
        {
            var item = e.Current;
            list.Add(item);
        }
        return list;
    }
    
    //Implementation for IEnumerable
    public IEnumerable<T> Where<T>(this IEnumerable<T> e, Predicate predicate) 
    {
        var enumerator = e.GetEnumerator();
        while (enumerator.MoveNext())
        {
            var item = e.Current;
            if (predicate(item))
                yield return item;
        }
    }
    
    //Implementation for IQueryable
    public IQueryable<T> Where<T>(this IQueryable<T> e, Expression<Predicate> predicate) 
    {
        MethodBase method = ...; // create generic method of Queryable.Where()
        return e.Provider
            .CreateQuery<T>(Expression.Call(null, method, e.Expression, Expression.Quote(predicate)));
    }
