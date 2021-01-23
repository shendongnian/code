    class Program
    {
        static void Main(string[] args)
        {           
            Foo myObj = TypeResolver.Get<Foo>("Foo data");            
        }
    }
    class TypeResolver
    {
        public static T Get<T>(object obj)
        {
            if (typeof(T).CanExplicitlyCastFrom<string>())
            {                             
                return obj.CastTo<T>();
            }
            return default(T);
        }
    }
    public static class Extensions
    {
        public static bool CanExplicitlyCastFrom<T>(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            
            var paramType = typeof(T);
            var castOperator = type.GetMethod("op_Explicit", 
                                            new[] { paramType });
            if (castOperator == null)
                return false;
            var parametres = castOperator.GetParameters();
            var paramtype = parametres[0];
            if (paramtype.ParameterType == typeof(T))
                return true;
            else
                return false;
        }
        public static T CastTo<T>(this object obj)
        {            
            var castOperator = typeof(T).GetMethod("op_Explicit", 
                                            new[] { typeof(string) });
            if (castOperator == null)
                throw new InvalidCastException("Can't cast to " + typeof(T).Name);
            return (T)castOperator.Invoke(null, new[] { obj });
        }
    }
