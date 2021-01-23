    public class GenericClass
    {
        public static object GetInstance(Type type)
        {
            var genericType = typeof(GenericClass<>).MakeGenericType(type);
            return Activator.CreateInstance(genericType);
        }
    }
