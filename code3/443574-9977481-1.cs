    /// <summary>
    /// Default constructor needed for COM. Set parameters with properties.
    /// </summary>
    public STARConnection()
    {
    }
	public Initialize(string username, string password, int loginTimeout, int overallTimeout)
	{
		output = "";
		conn = new TelnetConnection("HOSTHOSTHOST", 23);
		this.SetTimeout(overallTimeout);
		try
		{
			output = conn.Login(username, password, loginTimeout);
			if(output.Contains("You entered an invalid login name or password"))
			{
				throw new LoginException("Failed to login");
			}
			this.ParsePrompt();
		}
		catch(Exception e)
		{
			if(e.Message.Contains("login prompt"))
			{
				throw new PromptException("Login", "Could not find login prompt");
			}
			else if(e.Message.Contains("password prompt"))
			{
				throw new PromptException("Password", "Could not find password prompt");
			}
			else
			{
				throw e;
			}
		}
	}
