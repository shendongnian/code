    class Directory : DynamicObject
    {
        public string Value { get; set; }
        public Dictionary<string, Directory> SubDirectories { get; set; }
    	
    	public Directory()
    	{
    		SubDirectories = new Dictionary<string, Directory>();
    	}
    	
    	public override bool TryGetMember(GetMemberBinder binder, out Object result)
    	{
    		if (!SubDirectories.ContainsKey(binder.Name))
    			SubDirectories[binder.Name] = new Directory();
    
    		result = SubDirectories[binder.Name];	
    		return true;
    	}
    	
    	public override bool TrySetMember(SetMemberBinder binder, Object value)
    	{
    		if (!SubDirectories.ContainsKey(binder.Name))
    			SubDirectories[binder.Name] = new Directory();
    			
    		SubDirectories[binder.Name].Value = value.ToString();
    		return true;
    	}
    	
    	public override string ToString()
    	{
    		return Value;
    	}
    } 
