    private static string CombineNoChecks(string path1, string path2)
    {
    	if (path2.Length == 0)
    	{
    		return path1;
    	}
    	if (path1.Length == 0)
    	{
    		return path2;
    	}
    	if (Path.IsPathRooted(path2))
    	{
    		return path2;
    	}
    	char c = path1[path1.Length - 1];
    	if (c != Path.DirectorySeparatorChar && c != Path.AltDirectorySeparatorChar && c != Path.VolumeSeparatorChar)
    	{
    		return path1 + Path.DirectorySeparatorChar + path2;
    	}
    	return path1 + path2;
    }
