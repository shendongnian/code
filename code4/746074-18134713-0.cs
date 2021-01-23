	private U23.Session _axSession = new U23.Session();
	public U23.Session Connection
	{
		get
		{
			return this._axSession;
		}
	}
	/// <summary>
	/// Checks to see if the AX session is connected. If it's null we return false. 
	/// Then we check to see if it's logged in, then return true. Otherwise it's not logged in.
	/// </summary>
	public bool Connected
	{
		get
		{
			if (this._axSession == null)
			{
				return false;
			}
			else if (this._axSession.isLoggedOn())
			{
				return true;
			}
			return false;
		}
	}
	/// <summary>
	/// This connects to the AX session. If it's already connected then we don't need to connect
	/// again, so we return true. Otherwise we'll try to initiate the session. 
	/// </summary>
	/// <returns>
	/// True: Connection openned successfully, or was already open.
	/// False: Connection failed.
	/// </returns>
	public bool OpenConnection()
	{
		if (this.Connected)
		{
			return true;
		}
		else
		{
			try
			{
				_axSession.Logon(null, null, null, null);
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
	/// <summary>
	/// If the session is logged on we will try to close it.
	/// </summary>
	/// <returns>
	/// True: Connection closed successfully
	/// False: Problem closing the connection
	/// </returns>
	public bool CloseConnection()
	{
		bool retVal = false;
		if (this.Connection.isLoggedOn())
		{
			try
			{
				_axSession.Logoff();
				retVal = true;
			}
			catch
			{
				retVal = false;
			}
		}
		else
		{
			retVal = true;
		}
		this.Connection.Dispose();
		return retVal;
	}
