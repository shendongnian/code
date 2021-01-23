	public static class Configuration
	{
		/// <summary>
		/// Get the number of minutes before prior to the event that the server is started.
		/// </summary>
		public static int ServerLoadTime
		{
			get
			{
				if (ConfigurationManager.AppSettings["ServerLoadTime"] != null)
					return int.Parse(ConfigurationManager.AppSettings["ServerLoadTime"]);
				Logging.Write("ServerLoadTime is missing from the Configuration file.", EventLogEntryType.Warning, Logging.Sources.General, "Configuration.ServerLoadTime", null);
				return -30; // return a default value.
			}
		}
