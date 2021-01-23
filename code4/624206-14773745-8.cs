    interface IEditableStateProvider
    {
    	 IEditableStateProvider For(object target);
    	 IEditableStateProvider ExcludePropertyNames(params Expression<Func<object>>[] excludedProperties);
    } 
    class Provider : IEditableStateProvider
    {
    	public IEditableStateProvider For(object target) 
    	{ 
    		// dummy
    		return this;
    	}
    	public IEditableStateProvider ExcludePropertyNames(params Expression<Func<object>>[] excludedProperties) 
    	{
    		// dummy
    		return this;
    	}
    }
    var myClass = new List<object>();
    new Provider().For(myClass).ExcludePropertyNames(() => myClass.Count);
