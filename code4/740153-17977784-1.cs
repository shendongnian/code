    public IEnumerable<TModel> Paginate(IQueryable<TModel> source, ref int totalPages, int pageIndex, int pageSize, string sortfield, SortDirection? sortdir)
    {
        totalPages = (int)Math.Ceiling(source.Count() / (double)pageSize);
    
        if (sortdir == SortDirection.Descending)
        {
             return source.OrderByDescending(GetSortExpression<TModel>(sortfield)).Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }
        else
        {
             return source.OrderBy(GetSortExpression<TModel>(sortfield)).Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }
    }
    
    private static Expression<Func<TModel,object>> GetSortExpression<TModel>(string name)
    {
        ParameterExpression pe = Expression.Parameter(typeof(TModel));
        Expression se = Expression.Convert( Expression.PropertyOrField(pe, name) , typeof(object));
        return Expression.Lambda<Func<TModel,object>>(se, pe);        
    }
