    public void QueryStatus(string commandName, vsCommandStatusTextWanted neededText, ref vsCommandStatus status, ref object commandText)
		{
			if(neededText == vsCommandStatusTextWanted.vsCommandStatusTextWantedNone)
			{
                if (loginOkay == 0)
                {
                    if (commandName == addInInstance.ProgID + "." + LOGIN_NAME)
                    {
                        status = (vsCommandStatus)vsCommandStatus.vsCommandStatusSupported;
                    }
                    if (commandName == addInInstance.ProgID + "." + LOGOUT_NAME ||
                        commandName == addInInstance.ProgID + "." + LOCK_NAME ||
                        commandName == addInInstance.ProgID + "." + UNLOCK_NAME ||
                        commandName == addInInstance.ProgID + "." + CHECKIN_NAME ||
                        commandName == addInInstance.ProgID + "." + CHECKOUT_NAME)
                    {
                        status = (vsCommandStatus)vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    }
                }
                else if (loginOkay == 1)
                {
                    if (commandName == addInInstance.ProgID + "." + LOGIN_NAME)
                    {
                        status = (vsCommandStatus)vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    }
                    if (commandName == addInInstance.ProgID + "." + LOGOUT_NAME ||
                        commandName == addInInstance.ProgID + "." + LOCK_NAME ||
                        commandName == addInInstance.ProgID + "." + UNLOCK_NAME ||
                        commandName == addInInstance.ProgID + "." + CHECKIN_NAME ||
                        commandName == addInInstance.ProgID + "." + CHECKOUT_NAME)
                    {
                        status = (vsCommandStatus)vsCommandStatus.vsCommandStatusSupported;
                    }
                }
                else
                {
                    status = vsCommandStatus.vsCommandStatusUnsupported;
                }
			}
		}
