    public static Expression<Func<TEntity, TResult>> GetExpression<TEntity, TResult>(string prop)
            {
                var param = Expression.Parameter(typeof(TEntity), "p");
                var parts = prop.Split('.');
    
                Expression parent = parts.Aggregate<string, Expression>(param, Expression.Property);
                Expression conversion = Expression.Convert(parent, typeof (object));
    
                var tryExpression = Expression.TryCatch(Expression.Block(typeof(object), conversion),
                                                        Expression.Catch(typeof(object), Expression.Constant(null))); 
    
                return Expression.Lambda<Func<TEntity, TResult>>(tryExpression, param);
            }
