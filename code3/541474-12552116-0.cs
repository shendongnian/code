    public sealed class StatusOptions {
    
    	private readonly int value;
    	public int Value
    	{
    	 get{ return value;}
    	}
    	private readonly string desc;
    	public string Description
    	{
    	 get{ return desc;}
    	}
    
    	public static readonly StatusOptions OptionDisabled  = new StatusOptions (0,"Disabled");
    	public static readonly StatusOptions OptionOk   = new StatusOptions (1, "Ok");
    
    	private StatusOptions(int value, string desc){
    		this.value = value;
                this.Description = desc;
    	}
    
    }
