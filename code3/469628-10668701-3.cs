    interface IContainer<T>
    {
    	void ContainObject(T obj);
    }
    
    class Container<T> : IContainer<T> where T : IContainableObject<T>
    {
    	T contained;
    	
    	public void ContainObject(T obj)
    	{
    	    contained = obj;
    	    contained.NotifyContained(this);
    	}
    }
    
    interface IContainableObject<T>
    {
    	void NotifyContained(IContainer<T> c);
    }
    
    class ImplementingType : IContainableObject<ImplementingType>
    {
    	public IContainer<ImplementingType> MyContainer;
    	
    	public void NotifyContained(IContainer<ImplementingType> c)
    	{
    		Debug.WriteLine("notify contained");
    		MyContainer = c;
    	}
    }
