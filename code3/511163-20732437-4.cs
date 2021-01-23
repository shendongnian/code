	public void QueryStatus(string commandName, vsCommandStatusTextWanted neededText, ref vsCommandStatus status, ref object commandText)
	{
		if(neededText == vsCommandStatusTextWanted.vsCommandStatusTextWantedNone)
		{
			if(commandName == "YourAddin.Connect.YourAddinCommandName")
			{
				status = (vsCommandStatus)vsCommandStatus.vsCommandStatusSupported|vsCommandStatus.vsCommandStatusEnabled;
				return;
			}
		}
	}
