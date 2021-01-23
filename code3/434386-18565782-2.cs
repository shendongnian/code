    public class Foo<T>
       where T : new()
    {
        public void SomeOperation()
        {
            T something = new T();
            ...
        }
    }
