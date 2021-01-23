    public static string GetFrameworkPath()
    {
    	var frameworkVersion = string.Format("v{0}.{1}.{2}", Environment.Version.Major, Environment.Version.Minor, Environment.Version.Build);
    	var is64BitProcess = Environment.Is64BitProcess;
    	var windowsPath = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
    	return Path.Combine(windowsPath, "Microsoft.NET", is64BitProcess ? "Framework64" : "Framework", frameworkVersion);	
    }
    
    public static string GetPathToVisualStudio(string version)
    {	
    	var is64BitProcess = Environment.Is64BitProcess;
    	var registryKeyName = string.Format(@"Software\{0}Microsoft\VisualStudio\SxS\VC7", is64BitProcess ? @"Wow6432Node\" : string.Empty);
    	var vsKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(registryKeyName);
    	var versionExists = vsKey.GetValueNames().Any(valueName => valueName.Equals(version));
    	if(versionExists)
    	{
    		return vsKey.GetValue(version).ToString();
    	}
    	else
    	{
    		return null;
    	}
    }
