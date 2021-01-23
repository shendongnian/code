	long GetTeamViewerId()
	{
		try
		{
			string regPath = Environment.Is64BitOperatingSystem ? @"SOFTWARE\Wow6432Node\TeamViewer" : @"SOFTWARE\TeamViewer";
			RegistryKey key = Registry.LocalMachine.OpenSubKey(regPath);
			if (key == null)
				return 0;
			object clientId = key.GetValue("ClientID");
			if (clientId != null) //ver. 10
				return Convert.ToInt64(clientId);
			foreach (string subKeyName in key.GetSubKeyNames().Reverse()) //older versions
			{
				clientId = key.OpenSubKey(subKeyName).GetValue("ClientID");
				if (clientId != null)
					return Convert.ToInt64(clientId);
			}
			return 0;
		}
		catch (Exception e)
		{
			return 0;
		}
	}
