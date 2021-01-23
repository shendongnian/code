     public static Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> GetOrderBy(string orderColumn, string orderType) {
                Type typeQueryable = typeof(IQueryable<TEntity>);
                ParameterExpression argQueryable = Expression.Parameter(typeQueryable, "p");
                var outerExpression = Expression.Lambda(argQueryable, argQueryable);
                string[] props = orderColumn.Split('.');
                IQueryable<TEntity> query = new List<TEntity>().AsQueryable<TEntity>();
                Type type = typeof(TEntity);
                ParameterExpression arg = Expression.Parameter(type, "x");
    
                Expression expr = arg;
                foreach(string prop in props) {
                    PropertyInfo pi = type.GetProperty(prop, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                    expr = Expression.Property(expr, pi);
                    type = pi.PropertyType;
                }
                LambdaExpression lambda = Expression.Lambda(expr, arg);
                string methodName = orderType == "asc" ? "OrderBy" : "OrderByDescending";
    
                MethodCallExpression resultExp =
                    Expression.Call(typeof(Queryable), methodName, new Type[] { typeof(TEntity), type }, outerExpression.Body, Expression.Quote(lambda));
                var finalLambda = Expression.Lambda(resultExp, argQueryable);
                return (Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>)finalLambda.Compile();
            }
