    public class MenuItem
    {
    	public string heading
    	{
    		get;
    		set;
    	}
    
    	public string link
    	{
    		get;
    		set;
    	}
    
    	public DropDownMenu[] dropdown
    	{
    		get;
    		set;
    	}
    }
    
    public class DropDownMenu
    {
    	public string Name
    	{
    		get;
    		set;
    	}
    	public string Value
    	{
    		get;
    		set;
    	}
    }
