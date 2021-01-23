    class Container<T>
    {
    	T contained;
    	public void ContainObject(T obj)
    	{
    		contained = obj;
    		var containable = obj as IContainableObject<T>;
    		if(containable != null)
    		{
    			containable.NotifyContained(this);
    		}
    	}
    }
    
    interface IContainableObject<T>
    {
    	void NotifyContained(Container<T> c);
    }
    
    class ImplementingType : IContainableObject<ImplementingType>
    {
    	public Container<ImplementingType> MyContainer;
    	public void NotifyContained(Container<ImplementingType> c)
    	{
    		MyContainer = c;
    	}
    }
