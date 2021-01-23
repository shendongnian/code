    class Directory<T> : DynamicObject
    {
        private T Value;
        private Dictionary<string, Directory<T>> SubDirectories;
    	
    	public Directory()
    	{
    		SubDirectories = new Dictionary<string, Directory<T>>();
    	}
    	
    	public override bool TryGetMember(GetMemberBinder binder, out Object result)
    	{
    		if (!SubDirectories.ContainsKey(binder.Name))
    			SubDirectories[binder.Name] = new Directory<T>();
    
    		result = SubDirectories[binder.Name];	
    		return true;
    	}
    	
    	public override bool TrySetMember(SetMemberBinder binder, Object value)
    	{
    		if (!SubDirectories.ContainsKey(binder.Name))
    			SubDirectories[binder.Name] = new Directory<T>();
    			
    		SubDirectories[binder.Name].Value = (T)value;
    		return true;
    	}
    	
    	public override string ToString()
    	{
    		return Value.ToString();
    	}
    } 
