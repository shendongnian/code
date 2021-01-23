    public MyControl()
	{
		InitializeComponent();
			 
		CommandBinding cb = new CommandBinding(CommandClass.MyCustomCommand, CommandBinding_Executed, CommandBinding_CanExecute);
		CommandManager.RegisterClassCommandBinding(typeof(Window), cb);
	}
