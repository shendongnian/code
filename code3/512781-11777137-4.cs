    public static class MyHelpers
    {
            public static Expression<Func<TReport, bool>> CreatePredicate<TReport>(this object predicateObject)
            {
                var parameterExpression = Expression.Parameter(typeof(TReport), "item");
                Expression memberExpression = parameterExpression;
                var objectDictionary = MakeDictionary(predicateObject);
                foreach (var entry in objectDictionary.Where(entry => typeof(TReport).GetProperty(entry.Key) == null))
                {
                   throw new ArgumentException(string.Format("Type {0} has no property {1}", typeof(TReport).Name, entry.Key));
                }
                var equalityExpressions = GetBinaryExpressions(objectDictionary, memberExpression).ToList();
                var body = equalityExpressions.First();
                body = equalityExpressions.Skip(1).Aggregate(body, Expression.And);
    
                return Expression.Lambda<Func<TReport, bool>>(body, new[] { parameterExpression });
            }
            private static IDictionary<string, object> MakeDictionary(object withProperties)
            {
                var properties = TypeDescriptor.GetProperties(withProperties);
                return properties.Cast<PropertyDescriptor>().ToDictionary(property => property.Name, property => property.GetValue(withProperties));
            }
    
            private static IEnumerable<BinaryExpression> GetBinaryExpressions(IDictionary<string, object> dic, Expression expression)
            {
                return dic.Select(m => Expression.Equal(Expression.Property(expression, m.Key), Expression.Constant(m.Value)));
            }
    }
