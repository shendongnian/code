    public class SomeClass<T>
    {
        public T DoSomething()
        {
            var obj = Activator.CreateInstance(this.GetType());
            // Do Things
            return (T)obj;
        }
    }
