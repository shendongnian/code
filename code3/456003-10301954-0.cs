    public interface IObject
    {
        string prop2
    }
    public class Object1 : IObject
    {
        string prop1;
        string prop2;
    }
    public class Object2 : IObject
    {
        string prop1;
        string prop2;
        int prop3;
    }
    public class ObjectService<T>
    where T is IObject
    {
        public T GetObject(T o) { return o; }
        public void SaveProperty2(T o, string i) { o.prop2 = i; }
    }
