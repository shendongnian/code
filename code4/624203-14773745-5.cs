    class Provider<T> : IEditableStateProvider<T>
    {
    	public IEditableStateProvider<T> For(T target) 
    	{ 
    		// dummy
    		return this;
    	}
    	public IEditableStateProvider<T> ExcludePropertyNames(params Expression<Func<T, object>>[] excludedProperties) 
    	{
    		// dummy
    		return this;
    	}
    }
    class Provider
    {
        // generic factory method to make use of type inference
    	public static IEditableStateProvider<T> For<T>(T obj)
    	{
    		return new Provider<T>().For(obj);
    	}
    }
