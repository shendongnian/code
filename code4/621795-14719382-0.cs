    static IEnumerable<TTable> Match<TTable, TField>(IQueryable<TTable> table, IEnumerable<TField> values, Expression<Func<TTable, TField>> fieldSelector)
    {
        var valuesConstant = Expression.Constant(values.Distinct());
        
        var callContains = Expression.Call(typeof(Enumerable), "Contains", new[] { typeof(TField) }, new Expression[] { valuesConstant, fieldSelector.Body });
        var whereExpression = Expression.Lambda<Func<TTable, bool>>(callContains, (fieldSelector.Body as MemberExpression).Expression as ParameterExpression);
        return table.Where(whereExpression);
    }
