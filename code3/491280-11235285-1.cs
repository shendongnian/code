    public abstract class BaseTestingCollections<T>
    {
        public BaseTestingCollections()
        {
            if (!typeof(ITest).IsAssignableFrom(typeof(T)) && !typeof(IBoldface).IsAssignableFrom(typeof(T)))
                throw new Exception();
        }
    }
