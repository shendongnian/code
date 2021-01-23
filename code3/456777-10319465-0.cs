    public class GenericClass
    {
        public static GenericClass<T> GetInstance<T>(T ignored)
            where T : class
        {
            return new GenericClass<T>();
        }
        public static GenericClass<T> GetInstance<T>()
            where T : class
        {
            return new GenericClass<T>();
        }
    }
