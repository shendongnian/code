    class Container<T> 
        where T : IContainableObject
    {
        public void ContainObject(T obj)
        {
            // Here you know that obj does always implement IContainableObject.
            obj.NotifyContained(this);   
        }
        ...
    }
