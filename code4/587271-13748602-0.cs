    public class MyClass<T> where T : BaseClass, IInterface
    {
        public MyClass(T value)
        {
            Register(value);
        }
    }
