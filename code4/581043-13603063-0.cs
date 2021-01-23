    public static IQueryable<T> WhereFilter<T>(this IQueryable<T> source, string[] possibleValues, params Expression<Func<T, string>>[] selectors)
    {
        List<Expression> expressions = new List<Expression>();
        var param = Expression.Parameter(typeof(T), "p");
        var bodies = new List<MemberExpression>();
        foreach (var s in selectors)
        {
            bodies.Add(Expression.Property(param, ((MemberExpression)s.Body).Member.Name));
        }
        foreach (var v in possibleValues)
        {
            foreach(var b in bodies) {
                expressions.Add(Expression.Call(b, "Contains", null, Expression.Constant(v)));
            }
        }
        var finalExpression = expressions.Aggregate((accumulate, equal) => Expression.Or(accumulate, equal));
        return source.Where(Expression.Lambda<Func<T, bool>>(finalExpression, param));
    }
