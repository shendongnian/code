    static public class FieldInfoExtensions
    {
        static public Func<S, T> CreateGetFieldDelegate<S, T>(this FieldInfo fieldInfo)
        {
            var instExp = Expression.Parameter(typeof(S));
            var fieldExp = Expression.Field(instExp, fieldInfo);
            return (Func<S,T>)Expression.Lambda<Func<S, T>>(fieldExp, instExp).Compile();
        }
    }
