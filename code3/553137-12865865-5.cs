    public class TypeWrapper<T>
    {
        public Type Type { get; private set; }
        public TypeWrapper(Type t)
        {
            if (!typeof(T).IsAssignableFrom(t)) throw new Exception();
            Type = t;
        }
        public static implicit operator TypeWrapper<T>(Type t) {
            return new TypeWrapper<T>(t);
        }
    }
