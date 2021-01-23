    public static void Copy(string src, string dest)
    {
    	// copy all files
    	foreach (string file in Directory.GetFiles(src))
    	{
    		try
    		{
    			File.Copy(file, Path.Combine(dest, Path.GetFileName(file)));
    		}
    		catch (PathTooLongException)
    		{
    		}
    		// catch any other exception that you want.
    		// List of possible exceptions here: http://msdn.microsoft.com/en-us/library/c6cfw35a.aspx
    	}
    
    	// go recursive on directories
    	foreach (string dir in Directory.GetDirectories(src))
    	{
    			
    		// First create directory...
    		// Instead of new DirectoryInfo(dir).Name, you can use any other way to get the dir name,
    		// but not Path.GetDirectoryName, since it returns full dir name.
    		string destSubDir = Path.Combine(dest, new DirectoryInfo(dir).Name);
    		Directory.CreateDirectory(destSubDir);
    		// and then go recursive
    		Copy(dir, destSubDir);
    	}
    }
