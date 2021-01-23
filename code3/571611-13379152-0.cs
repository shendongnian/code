    public IEnumerable<T> GetAllPagingAndSorting(out int totalRecords, int pageSize, int pageIndex, string orderingKey, string sortDir, params Expression<Func<T, object>>[] includes)
            {
                    IQueryable<T> results = Entities;
    
                    totalRecords = results.Count();
    
                    // apply any includes
                    if (includes != null)
                    {
                        results = includes.Aggregate(results, (current, include) => current.Include(include));
                    }
    
                    // apply sorting    
                    results = GetSortDirection(sortDir) == SortDirection.Ascending ? ApplyOrder(results, orderingKey, ORDERBY) : ApplyOrder(results, orderingKey, ORDERBYDESC);
                    
                
                    if (pageSize > 0 && pageIndex >= 0)
                    {
                        // apply paging
                        results = results.Skip(pageIndex * pageSize).Take(pageSize);
                    }
    
                    return results.ToList();
            }
     protected static IOrderedQueryable<T> ApplyOrder(IQueryable<T> source, string property, string methodName)
            {
                string[] props = property.Split('.');
                Type type = typeof(T);
                ParameterExpression arg = Expression.Parameter(type, "m");
                Expression expr = arg;
                foreach (string prop in props)
                {
                    // use reflection (not ComponentModel) to mirror LINQ
                    PropertyInfo pi = type.GetProperty(prop);
                    expr = Expression.Property(expr, pi);
                    type = pi.PropertyType;
                }
                Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
                LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);
    
                object result = typeof(Queryable).GetMethods().Single(
                        method => method.Name == methodName
                                && method.IsGenericMethodDefinition
                                && method.GetGenericArguments().Length == 2
                                && method.GetParameters().Length == 2)
                        .MakeGenericMethod(typeof(T), type)
                        .Invoke(null, new object[] { source, lambda });
                return (IOrderedQueryable<T>)result;
            } 
