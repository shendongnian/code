    public interface IObjectExpressionCreator<T>
    {
        Expression<Func<T, TResult>> Property<TResult>(string name);
    }
    public static class PropertyExpression
    {
        private class ObjectExpressionCreator<T> : IObjectExpressionCreator<T>
        {
            public Expression<Func<T, TResult>> Property<TResult>(string name)
            {
                var p = Expression.Parameter(typeof(T),
                                             "propertyOrFieldContainer");
                var body = Expression.PropertyOrField(p, name);
                var lambda = Expression.Lambda(typeof(Func<T, TResult>),
                                               body,
                                               p);
                return (Expression<Func<T, TResult>>)lambda;
            }
        }
        public static IObjectExpressionCreator<T> For<T>()
        {
            return new ObjectExpressionCreator<T>();
        }
    }
