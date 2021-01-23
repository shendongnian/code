    class YesNoVariable : MasterClass
    {
    	public bool YesNo { get; set; }
    	
    	public YesNoVariable()
    	{
    		hookMethod();
    	}
    	
    	protected void hookMethod()
    	{	
    		newHookAndAdd(value => YesNo = value, () => YesNo, "yesno", (input) => input == "yes");
    	}
    }
