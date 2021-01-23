    public static Func<T,T,bool> MakeComparator<T>() {
        var lhs = Expression.Parameter(typeof (T));
        var rhs = Expression.Parameter(typeof (T));
        var allPropChecks = typeof(T)
            .GetProperties()
            .Where(p => p.CanRead && p.GetIndexParameters().Length == 0)
            .Select(p => Expression.Equal(Expression.Property(lhs, p), Expression.Property(rhs, p)))
            .ToList();
        Expression compare;
        if (allPropChecks.Count == 0) {
            return (a,b) => true; // Objects with no properties are the same
        } else {
            compare = allPropChecks[0];
            compare = allPropChecks
                .Skip(1)
                .Aggregate(compare, Expression.AndAlso);
        }
        return (Func<T, T, bool>)Expression.Lambda(compare, new[] { lhs, rhs }).Compile();
    }
