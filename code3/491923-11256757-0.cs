    public static class ExpressionCreator
    {
        public static Func<T, TProperty> CreatePropertyAccessExpression<T, TProperty>(string propertyName)
        {
            var tType = typeof (T);
            var property = tType.GetProperty(propertyName);
            var parameterExpression = Expression.Parameter(tType);
            var memberAccessExpression = Expression.MakeMemberAccess(parameterExpression, property);
            var lambda = Expression.Lambda<Func<T, TProperty>>(memberAccessExpression, parameterExpression);
            return lambda.Compile();
        }
    }
