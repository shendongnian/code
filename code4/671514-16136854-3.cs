    static public class TypeExtensions
    {
        static public Func<S, T> CreateGetFieldDelegate<S, T>(this Type type, string fieldName)
        {
            var instExp = Expression.Parameter(type);
            var fieldExp = Expression.Field(instExp, fieldName);
            return Expression.Lambda<Func<S, T>>(fieldExp, instExp).Compile();
        }
    }
