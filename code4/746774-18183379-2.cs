    public static IQueryable OrderBy(this IQueryable source, string ordering,
        params object[] values)
    {
        //This handles nulls in a complex object
        var orderingSplit = ordering.Split(new char[] {' '},
            StringSplitOptions.RemoveEmptyEntries);
        var sortField = orderingSplit[0];
        var splitted_sortField = sortField.Split(new char[] { '.' }, 
            StringSplitOptions.RemoveEmptyEntries);
        if (splitted_sortField.Length > 1)
        {
            sortField = "iif(" + splitted_sortField[0] + "==null,null," + sortField + ")";
        }
        ordering = orderingSplit.Length == 2
           ? sortField + " " + orderingSplit[1]
           : sortField;
        if (source == null) throw new ArgumentNullException("source");
        if (ordering == null) throw new ArgumentNullException("ordering");
        ParameterExpression[] parameters = new ParameterExpression[] {
            Expression.Parameter(source.ElementType, "") };
        ExpressionParser parser = new ExpressionParser(parameters, ordering, values);
        IEnumerable<DynamicOrdering> orderings = parser.ParseOrdering();
        Expression queryExpr = source.Expression;
        string methodAsc = "OrderBy";
        string methodDesc = "OrderByDescending";
        foreach (DynamicOrdering o in orderings)
        {
            queryExpr = Expression.Call(
                typeof(Queryable), o.Ascending ? methodAsc : methodDesc,
                new Type[] { source.ElementType, o.Selector.Type },
                queryExpr, Expression.Quote(Expression.Lambda(o.Selector, parameters)));
            methodAsc = "ThenBy";
            methodDesc = "ThenByDescending";
        }
        return source.Provider.CreateQuery(queryExpr);
    }
