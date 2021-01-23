    class TypeName
    {
    	public TypeName(string name)
    	{
    		var index = name.LastIndexOf(',');
    		if (index > 0)
    		{
    			Name = name.Substring(0, index).Trim();
    
    			AssemblyName = new AssemblyName(name.Substring(index + 1).Trim());
    		}
    		else
    		{
    			Name = name;	
    		}
    	}
    
    	public string Name { get; private set; }
    
    	public AssemblyName AssemblyName { get; private set; }
    }
