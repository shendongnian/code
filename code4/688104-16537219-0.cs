    public interface IClass<T> where T : IObject
    {
        bool SomeMethod(T item);
    }
    public ClassImplementation : IClass<ObjectImplementation>
    {
        public bool SomeMethod(ObjectImplementation item)
        {
    
        }
    }
