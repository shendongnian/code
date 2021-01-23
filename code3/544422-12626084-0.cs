    public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate, param string[] include)
    {
        IQueryable<T> query = this._ObjectSet;
        foreach(string inc in include)
        {
           query = query.Include(inc);
        }
        return query.Where(predicate);
    }
