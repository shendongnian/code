    public IQueryable<T> Query<T>(Expression<Func<T, bool>> expression = null)
         where T : class
    {
        IQueryable<T> query = GetTable<T>();
        query = query.Where(my1stWhereClause).Where(my2ndWhereClause);
        // Doing this dynamically doesn't really work..
        query = expression.OrderBy(x => x.My1stColumn)
                          .ThenBy(x => x.My2ndColumn);
        return expression != null ? query.Where(expression) : query;
    }
