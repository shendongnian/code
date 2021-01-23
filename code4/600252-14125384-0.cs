    public class Type1 { }
    public class Type2 { }
    public interface IParent
    {
        Type1 Get(string key);
    }
    public class Base<T, T2> 
    {
        public T Get(string key)
        {
            return default(T);
        }
    }
    public class Parent : Base<Type1, Type2>, IParent
    {
    }
