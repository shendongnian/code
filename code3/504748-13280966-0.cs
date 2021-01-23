    private List<BaseCommand> _commands = new List<BaseCommand>();
    [XmlElement(typeof(ExecuteCommand))]
    [XmlElement(typeof(WaitCommand))]
    public List<BaseCommand> Commands
    {
    	get
    	{
    		return _commands;
    	}
    	set
    	{
    		_commands = value;
    	}
    }
