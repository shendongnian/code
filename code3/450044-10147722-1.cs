    public interface IExample<T> where T : new()
    {
        T GetAnything();
    }
    public class Get : IExample<MyType>
    {
        public MyType GetAnything()
        {
            MyType mt = new MyType();
            return mt;
        }
    }
    public class MyType
    {
        // ...
    }
