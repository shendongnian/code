    interface ISomething
    {
        object GetObject();
    }
    interface ISomething<T> : ISomething
        where T : ISomeObject
    {
        T GetObject();
    }
    public class SomeImplementation<T> : ISomething<T>
    {
        public T GetObject()
        {
            ...
        }
        object ISomething.GetObject()
        {
            return this.GetObject(); // Calls non generic version
        }
    }
