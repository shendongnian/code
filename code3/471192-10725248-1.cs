        public LambdaExpression PropertyGetLambda(Type parameterType, string propertyName, Type propertyType)
        {
            var parameter = Expression.Parameter(parameterType);
            var memberExpression = Expression.Property(parameter, propertyName);
            var lambdaExpression = Expression.Lambda(memberExpression, parameter);
            return lambdaExpression;
        }
