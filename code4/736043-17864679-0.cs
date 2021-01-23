    var filterList = new[] { "new", "old", "current" };
    var param = Expression.Parameter(typeof(Item));
    var left = 
        Expression.Call(
            Expression.Call(
                Expression.PropertyOrField(param, "Type"),
                typeof(string).GetMethod("ToLower", Type.EmptyTypes)),
            typeof(string).GetMethod("Trim", Type.EmptyTypes));
    var filterExpr = (Expression<Func<Item, bool>>)Expression.Lambda(
        filterList
            .Select(f => Expression.Equal(left, Expression.Constant(f)))
            .Aggregate((l, r) => Expression.OrElse(l, r)), 
        param);
    var filteredItems = items.Where(filterExpr);
