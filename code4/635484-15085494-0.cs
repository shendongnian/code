    public class MyClass<T>
    {
        public T MyField;
        public T MyProp { get; set; }
        public MyClass<T> MyMethod<T>(T k)
        {
            return new MyClass<T>();
        }
    }
