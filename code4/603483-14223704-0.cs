    List<string> dirs = Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)).ToList();
    string[] mySubDirs;
    
    for (int i = 0; i < dirs.Count-1; i++)
    {
    	try
    	{
    		mySubDirs = Directory.GetDirectories(dirs[i]);
    	}
    	catch (Exception)
    	{
    		dirs.RemoveAt(i);
    	}
    }
