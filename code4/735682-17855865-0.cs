        private static Expression<Func<T, bool>> CreateLike<T>(PropertyInfo prop, string value)
        {
            var parameter = Expression.Parameter(typeof(T), "f");
            var propertyAccess = Expression.MakeMemberAccess(parameter, prop);
            
            var indexOf = Expression.Call(propertyAccess, "IndexOf", null, Expression.Constant(value, typeof(string)),Expression.Constant(StringComparison.InvariantCultureIgnoreCase));
            var like=Expression.GreaterThanOrEqual(indexOf, Expression.Constant(0));
            return Expression.Lambda<Func<T, bool>>(like, parameter);
        }
