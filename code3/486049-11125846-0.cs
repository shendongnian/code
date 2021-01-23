        private static IQueryable<TEntity> DynamicContains<TEntity, TProperty>(IQueryable<TEntity> query, Expression<Func<TEntity, TProperty>> property, IEnumerable<TProperty> values)
        {
            var memberExpression = property.Body as MemberExpression; 
            if (memberExpression == null || !(memberExpression.Member is PropertyInfo)) 
            { 
                throw new ArgumentException("Property expression expected", "property"); 
            }
            // get the generic .Contains method
            var containsMethod =
                typeof(Enumerable)
                .GetMethods()
                .Single(m => m.Name == "Contains" && m.GetParameters().Length == 2);
            // convert the generic .Contains method so that is matches the type of the property
            containsMethod = containsMethod.MakeGenericMethod(typeof(TProperty));
            // build e => Enumerable.Contains(values, e.Property)
            var lambda = 
                Expression.Lambda<Func<TEntity, bool>>(
                    Expression.Call(
                        containsMethod, Expression.Constant(values), property.Body), 
                        property.Parameters.Single());
            // return query.Where(e => Enumerable.Contains(values, e.Property))
            return query.Where(lambda);
        }
