    [DebuggerNonUserCode]
    public static bool IsArchive(string filename)
    {
    	bool result = false;
    	try
    	{
    		result = IsArchive(File.OpenRead(filename));
    	}
    	catch
    	{
    
    	}
    	return result;
    }
