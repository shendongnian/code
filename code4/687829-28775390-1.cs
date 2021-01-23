	static bool IsFlashLoadedInFirefox()
	{
		return Process.GetProcessesByName("plugin-container").Any(x => ProcessContainsModule(x, "NPSWF"));
	}
	static bool IsFlashLoadedInInternetExplorer()
	{
		//This doesn't work. For some reason can't get modules from child processes
		return Process.GetProcessesByName("iexplore").Any(x => ProcessContainsModule(x, "Flash32"));
	}
	static bool IsFlashLoadedInChrome()
	{
		//Doesn't work reliably. See description.
		return Process.GetProcessesByName("chrome").Any(x => ProcessContainsModule(x, "pepflashplayer"));
	}
