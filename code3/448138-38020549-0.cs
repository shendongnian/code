    public static string NativeSystemPath
    {
    	get
    	{
    		if (Environment.Is64BitOperatingSystem)
    		{
    			return System.IO.Path.Combine(
    				Environment.GetFolderPath(Environment.SpecialFolder.Windows),
    				"Sysnative");
    		}
    		return Environment.GetFolderPath(Environment.SpecialFolder.System);
    	}
    }
