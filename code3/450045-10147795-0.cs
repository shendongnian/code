    public class Get : IExample
    {
        public T GetAnything<T>()
        {
            return default(T);
        }
    }
    public void X()
    {
        var get = new Get();
        var mt = get.GetAnything<MyType>();
    }
