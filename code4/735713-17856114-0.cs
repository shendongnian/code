       public static Expression<Func<T, bool>> FilterKey<T>(string filterText, params string[] properties)
            {
                ParameterExpression parameter = Expression.Parameter(typeof (T));
                Expression[] propertyExpressions = properties.Select(
                    x => !string.IsNullOrEmpty(x) ? GetDeepPropertyExpression(parameter, x) : null).ToArray();
    
                Expression like= propertyExpressions.Select(expression => Expression.Call(expression, typeof (string).GetMethod("ToLower", Type.EmptyTypes))).Select(toLower => Expression.Call(toLower, typeof (string).GetMethod("Contains"), Expression.Constant(filterText.ToLower()))).Aggregate<MethodCallExpression, Expression>(null, (current, ex) => BuildOrExpression(current, ex));
                return  Expression.Lambda<Func<T, bool>>(like, parameter);
            }
    
            private static Expression BuildOrExpression(Expression existingExpression, Expression expressionToAdd)
            {
                if (existingExpression == null)
                {
                    return expressionToAdd;
                }
    
                //Build 'OR' expression for each property
                return Expression.OrElse(existingExpression, expressionToAdd);
            }
    
       
           private static Expression GetDeepPropertyExpression(Expression initialInstance, string property)
            {
                Expression result = null;
                foreach (string propertyName in property.Split('.'))
                {
                    Expression instance = result ?? initialInstance;
                    result = Expression.Property(instance, propertyName);
                }
                return result;
            }
