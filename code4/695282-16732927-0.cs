    public static IQueryable<T> GetAllOrRestrict<T>(this IQueryable<T> queryable,
     Expression<Func<T, bool>> predicate, 
     bool includeNullValues)
        {
            var expression = predicate.Body as BinaryExpression;
            var rightPart = expression.Right as MemberExpression;
            var value = GetValue(rightPart);
            var test = value.ToString();
            int val;
            if (Int32.TryParse(value.ToString(), out val))
            {
                if (val != 0)
                {
                    if (includeNullValues)
                    {
                        var parameter = Expression.Parameter(typeof(T),"m");
                        
                        return queryable.Where(predicate) <====HOW to " || depID == null) ???
                    }
                    else
                    {
                    return queryable.Where(predicate);
                    }
                }
            }
            return queryable;
        }
