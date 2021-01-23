    public ApiEntities Content = new ApiEntities();
    public IQueryable<T> GetCustomQuery<T>(System.Linq.Expressions.Expression<Func<T, bool>> where) where T : EntityObject
    {
       return Content.CreateObjectSet<T>().Where(where);
    }
