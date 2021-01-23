	public void Exec(string commandName, vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled)
	{
		handled = false;
		if(executeOption == vsCommandExecOption.vsCommandExecOptionDoDefault)
		{
			if(commandName == "BreakInCurrentDocument.Connect.BreakInCurrentDocument")
			{
                // here's where the magic happens
                // ******************************
                var activeWindow = _applicationObject.ActiveWindow;
                _applicationObject.Debugger.Break();
                if (_applicationObject.ActiveWindow != activeWindow)
                {
                    _applicationObject.ActiveWindow.Close(vsSaveChanges.vsSaveChangesNo);
                }
                // ******************************
				handled = true;
				return;
			}
		}
	}
