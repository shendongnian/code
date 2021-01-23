	Outlook.Application application = null;
	// Check whether there is an Outlook process running.
	if (Process.GetProcessesByName("OUTLOOK").Count() > 0)
	{
		// If so, use the GetActiveObject method to obtain the process and cast it to an Application object.
		application = Marshal.GetActiveObject("Outlook.Application") as Outlook.Application;
	}
	else
	{
		// If not, create a new instance of Outlook and log on to the default profile.
		application = new Outlook.Application();
		Outlook.NameSpace nameSpace = application.GetNamespace("MAPI");
		nameSpace.Logon("", "", Missing.Value, Missing.Value);
		nameSpace = null;
	}
