	//Acceptance test this method
	public static bool Is32BitOS()
	{
		var managementObjects = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem").Get().OfType<ManagementObject>();
		
		string os = (from x in managementObjects select x.GetPropertyValue("Caption")).First().ToString().Trim();
		string architecture = (from x in managementObjects select x.GetPropertyValue("OSArchitecture")).First().ToString();
		return Is32BitOS(os, architecture);
	}
	//Unit test this method
	protected static bool Is32BitOS(string os, string architecture)
	{
		if (os.Equals("Microsoft Windows XP Professional"))
		{
			return true;
		}
		if (os.StartsWith("Microsoft Windows 7"))
		{
			string architecture = archRetriever();
			if (architecture == "64-bit")
			{
				return false;
			}
		}
		return true;
	}
