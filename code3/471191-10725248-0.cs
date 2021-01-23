        public LambdaExpression PropertyGetLambda(string parameterName, Type parameterType, string propertyName, Type propertyType)
        {
            var parameter = Expression.Parameter(parameterType, parameterName);
            var memberExpression = Expression.Property(parameter, propertyName);
            var lambdaExpression = Expression.Lambda(memberExpression, parameter);
            return lambdaExpression;
        }
