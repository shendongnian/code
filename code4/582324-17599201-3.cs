    const string exeSuffix = ".exe";
    string path = progId + @"\shell\open\command";
    FileInfo browserPath;
    using ( RegistryKey pathKey = Registry.ClassesRoot.OpenSubKey( path ) )
    {
    	if ( pathKey == null )
    	{
    		return;
    	}
    
    	// Trim parameters.
    	try
    	{
    		string path = pathKey.GetValue( null ).ToString().ToLower().Replace( "\"", "" );
    		if ( !path.EndsWith( "exe" ) )
    		{
    			path = path.Substring( 0, path.LastIndexOf( exeSuffix, StringComparison.Ordinal ) + exeSuffix.Length );
    			browserPath = new FileInfo( path );
    		}
    	}
    	catch
    	{
    		// Assume the registry value is set incorrectly, or some funky browser is used which currently is unknown.
    	}
    }
