    public static bool ZipHasFile(string fileFullName, string zipFullPath)
    {
    	using (ZipArchive archive = ZipFile.OpenRead(zipFullPath))  //safer than accepted answer
    	{
    		foreach (ZipArchiveEntry entry in archive.Entries)
    		{
    			if (entry.FullName.EndsWith(fileFullName, StringComparison.OrdinalIgnoreCase))
    			{
    				return true;
    			}
    		}
    	}
    	return false;
    }
