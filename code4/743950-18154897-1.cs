    public class MyClass<T>
        where T : new()
    {
        public void MyMethod(params T[] items)
        {
            //...Do stuff...
        }
    }
