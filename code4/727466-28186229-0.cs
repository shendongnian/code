    ParameterExpression param = Expression.Parameter(typeof(EntityName), "aName");
    int[] ids = new int[] { 1, 2, 8 };
    Expression<Func<EntityName, bool>> aLambda = Expression.Lambda<Func<EntityName, bool>>(
        Expression.Equal(Expression.Call(
        Expression.Property(param, "FieldName"),
        typeof(int[]).GetMethod("Contains"), 
        new Expression[] { Expression.Constant(ids, ids.GetType()) }),
        Expression.Constant(true)), 
        param);
