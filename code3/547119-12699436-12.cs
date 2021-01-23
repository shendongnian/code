    class Attachvariable : MasterClass
    {
    	public int UserID { get; set; }
    	public string Position { get; set; }
    	public bool YesNo { get; set; }
    	public bool ProperBoolean { get; set; }
    	
    	public Attachvariable()
    	{
    		RegisterProperties();
    	}
    	
    	protected void RegisterProperties()
    	{	
    		RegisterProperty(value => UserID = value, () => UserID, "userID");
    		RegisterProperty(value => Position = value, () => Position, "position");
    		RegisterProperty(value => YesNo = value, () => YesNo, "yesno", (input) => input == "yes");
    		RegisterProperty(value => ProperBoolean = value, () => ProperBoolean, "ProperBoolean", (input) => Boolean.Parse(input));
    	}
    }
