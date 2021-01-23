	protected override void Initialize()
	{
		base.Initialize();
		// Add our command handlers (commands must exist in the .vsct file)
		OleMenuCommandService mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
		if ( null != mcs )
		{
			// "View My Tool Window" command callback
			CommandID menuCommandID = new CommandID(new Guid("{11111111-1111-1111-1111-111111111111}"), (int)0x500);
			MenuCommand menuItem = new MenuCommand(ShowToolWindow, menuCommandID);
			mcs.AddCommand(menuItem);
		}
	}
