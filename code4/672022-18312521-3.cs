	public static bool Is32BitOS()
	{
		var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
		
		return Is32Bit((s)=>{ (from x in s.Get().OfType<ManagementObject>() select x.GetPropertyValue("Caption")).First().ToString().Trim()},
					   (s)=>{ (from x in s.Get().OfType<ManagementObject>() select x.GetPropertyValue("OSArchitecture")).First().ToString();},
					   searcher);
	}
