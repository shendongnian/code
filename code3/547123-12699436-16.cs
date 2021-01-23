    class Attachvariable : MasterClass
    {
    	public int UserID { get; set; }
    	public string Position { get; set; }
    	
    	public Attachvariable()
    	{
    		hookMethod();
    	}
    	
    	protected void hookMethod()
    	{	
    		newHookAndAdd(value => UserID = value, () => UserID, "userID");
    		newHookAndAdd(value => Position = value, () => Position, "position");
    	}
    }
