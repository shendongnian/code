    class Container<T>
    {
    	T contained;
    	public void ContainObject(T obj)
    	{
    		contained = obj;
    		var containable = obj as IContainableObject;
    		if(containable != null)
    		{
    			containable.NotifyContained(this);
    		}
    	}
    }
    
    interface IContainableObject
    {
    	void NotifyContained<T>(Container<T> c);
    }
    
    interface IContainerObject{}
    
    
    class ImplementingType : IContainerObject
    {
    	public Container<ImplementingType> MyContainer;
    	public void NotifyContained(Container<ImplementingType> c)
    	{
    		MyContainer = c;
    	}
    }
