    public class BaseObject
    {
        string prop1;
        string prop2
    }
    
    public class Object1 : BaseObject
    {
    }
    
    public class Object2 : BaseObject
    {
        int prop3;
    }
    
    public class ObjectService<T> where T is BaseObject
    {
        public T GetObject(T o) { return o; }
        public void SaveProperty2(T o, string i) { o.prop2 = i; }
    }
