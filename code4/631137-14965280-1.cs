    public class Child : Parent
    {
    	public string NewInfo { get; set; }
    
    	public Child(Parent copy)
    		: base(copy)
    	{
    		
    	}
    }
