    public void Exec(string commandName, vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled)
		{
			handled = false;
			if(executeOption == vsCommandExecOption.vsCommandExecOptionDoDefault)
			{
				if(commandName == "MyAddin1.Connect.MyAddin1")
				{
                    //_applicationObject.ActiveWindow.WindowState.
                    _applicationObject.ExecuteCommand("Window.NewWindow");
                    _applicationObject.ExecuteCommand("Window.NewVerticalTabGroup");
					handled = true;
					return;
				}
			}
		}
