    public void Exec(string commandName, vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled)
	{
		handled = false;
		if (executeOption == vsCommandExecOption.vsCommandExecOptionDoDefault)
		{
			if (commandName == "MyAddin4.Connect.MyAddin4")
			{
				OutputWindow outputWindow = (OutputWindow)_applicationObject.Windows.Item(Constants.vsWindowKindOutput).Object;
				OutputWindowPane outputPane = outputWindow.OutputWindowPanes.Add("Processor");
				System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(OutputStringThread));
				thread.Start(outputPane);
				handled = true;
				return;
			}
		}
	}
	private void OutputStringThread(object obj)
	{
		try
		{
			OutputWindowPane outputPane = (OutputWindowPane)obj;
			for (int i = 0; i < 10; i++)
			{
				System.Threading.Thread.Sleep(500);
				outputPane.Activate();
				outputPane.OutputString(i + "\n");
			}
		}
		catch (Exception ex)
		{
			// Handle exception
		}
	}
