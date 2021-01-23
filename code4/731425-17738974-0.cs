        static List<Func<TEntity, TCriteria, bool>> GetCriteriaFunctions<TEntity, TCriteria>()
        {
            var criteriaFunctions = new List<Func<TEntity, TCriteria, bool>>();
            var criteriaProperties = typeof(TCriteria)
                .GetProperties()
                .Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>));
            foreach (var property in criteriaProperties)
            {
                var entityParameterExpression = Expression.Parameter(typeof(TEntity));
                var criteriaParameterExpression = Expression.Parameter(typeof(TCriteria));
                var criteriaPropertyExpression = Expression.Property(criteriaParameterExpression, property);
                var testingForEqualityExpression = Expression.Equal(
                    Expression.Convert(criteriaPropertyExpression, property.PropertyType.GetGenericArguments()[0]), 
                    Expression.Property(entityParameterExpression, property.Name));
                var body = Expression.Condition(
                    Expression.Equal(criteriaPropertyExpression, Expression.Constant(null)), 
                    Expression.Constant(true),
                    testingForEqualityExpression);
                var criteriaFunction = Expression.Lambda<Func<TEntity, TCriteria, bool>>(body, entityParameterExpression, criteriaParameterExpression).Compile();
                criteriaFunctions.Add(criteriaFunction);
            }
            return criteriaFunctions;
        }
