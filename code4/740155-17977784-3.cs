    public IEnumerable<TModel> Paginate(IQueryable<TModel> source, ref int totalPages, int pageIndex, int pageSize, string sortfield, SortDirection? sortdir)
    {
        totalPages = (int)Math.Ceiling(source.Count() / (double)pageSize);
    
        if (sortdir == SortDirection.Descending)
        {
             return source.OrderByDescending(sortfield).Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }
        else
        {
             return source.OrderBy(sortfield).Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }
    }
    public static class QueryableHelper
    {
        public static IQueryable<TModel> OrderBy<TModel>(this IQueryable<TModel> q, string name)
        {
            Type entityType = typeof(TModel);
            PropertyInfo p = entityType.GetProperty(name);
            MethodInfo m = typeof(QueryableHelper).GetMethod("OrderByProperty").MakeGenericMethod(entityType, p.PropertyType);
            return(IQueryable<TModel>) m.Invoke(null, new object[] { q, p });
        }
        public static IQueryable<TModel> OrderByDescending<TModel>(this IQueryable<TModel> q, string name)
        {
            Type entityType = typeof(TModel);
            PropertyInfo p = entityType.GetProperty(name);
            MethodInfo m = typeof(QueryableHelper).GetMethod("OrderByPropertyDescending").MakeGenericMethod(entityType, p.PropertyType);
            return (IQueryable<TModel>)m.Invoke(null, new object[] { q, p });
        }
        public static IQueryable<TModel> OrderByPropertyDescending<TModel, TRet>(IQueryable<TModel> q, PropertyInfo p)
        {
            ParameterExpression pe = Expression.Parameter(typeof(TModel));
            Expression se = Expression.Convert(Expression.Property(pe, p), typeof(object));
            return q.OrderByDescending(Expression.Lambda<Func<TModel, TRet>>(se, pe));
        }
        public static IQueryable<TModel> OrderByProperty<TModel, TRet>(IQueryable<TModel> q, PropertyInfo p)
        {
            ParameterExpression pe = Expression.Parameter(typeof(TModel));
            Expression se = Expression.Convert(Expression.Property(pe, p), typeof(object));
            return q.OrderBy(Expression.Lambda<Func<TModel, TRet>>(se, pe));
        }
    }
