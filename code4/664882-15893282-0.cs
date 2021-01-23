    public class Wrapper<T>
    {
        protected T _instance;
        public Wrapper(T instance)
        {
            this._instance = instance;
        }
        protected virtual void Precall()
        {
            // do something
        }
        protected virtual void Postcall()
        {
            // do something
        }
    }
