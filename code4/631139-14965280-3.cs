    public class Child
    {
    	private readonly Parent WrappedParent;
    
    	public string NewInfo { get; set; }
    	
    	public string Name 
    	{ 
    		get { return WrappedParent.Name; }
    		set { WrappedParent.Name = value; }
    	}
    	
    	public string City 
    	{ 
    		get { return WrappedParent.City; }
    		set { WrappedParent.City = value; }
    	}
    
    	public Child(Parent wrappedParent)
    	{
    		this.WrappedParent = wrappedParent;	
    	}
    }
