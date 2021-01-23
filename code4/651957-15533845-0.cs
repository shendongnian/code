    public static IQueryable<TEntity> OrderBy<TEntity>(
        this IQueryable<TEntity> source, 
        Expression<Func<TEntity, dynamic>> sortExpression, 
        bool descending)
        {
            var unary = sortExpression.Body as UnaryExpression;
            var operand = unary.Operand;
            Type actualExpressionType = operand.Type;
            MethodCallExpression resultExp = 
                Expression.Call(typeof(Queryable), 
                    descending? "OrderByDescending" : "OrderBy",
                    new Type[] { typeof(TEntity), actualExpressionType },
                    source.Expression, 
                    Expression.Lambda(operand, sortExpression.Parameters));
            return source.Provider.CreateQuery<TEntity>(resultExp);
        }
