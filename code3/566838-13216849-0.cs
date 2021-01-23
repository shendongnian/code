    public static class Mapper<T>
    {
        static Mapper()
        {
            var from = Expression.Parameter(typeof(T), "from");
            var to = Expression.Parameter(typeof(T), "to");
    
            var setExpressions = typeof(T)
                .GetProperties()
                .Where(property => property.CanRead && property.CanWrite && !property.GetIndexParameters().Any())
                .Select(property =>
                {
                    var getExpression = Expression.Call(from, property.GetGetMethod());
                    var setExpression = Expression.Call(to, property.GetSetMethod(), getExpression);
                    var equalExpression = Expression.Equal(Expression.Convert(getExpression, typeof(object)), Expression.Constant(null));
                        
                    return Expression.IfThen(Expression.Not(equalExpression), setExpression);
                });
    
            Map = Expression.Lambda<Action<T, T>>(Expression.Block(setExpressions), from, to).Compile();
        }
    
        public static Action<T, T> Map { get; private set; }
    }
