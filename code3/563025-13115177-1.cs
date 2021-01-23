    IEnumerable<string> imagesFileNames = FindImages(imagesFolder, "*.jpg", true);
    
    private IEnumerable<string> FindImages(string dir, string extension, bool isRecursive)
    try
    {
    	foreach (string d in Directory.GetDirectories(dir))
    	{
    		try
    		{
    			foreach (string f in Directory.GetFiles(d, extension))
    			{
    				imagesFileNames.Add(f);
    			}
    			if (isRecursive) FindImages(d,extension, true);
    		}
    		catch (Exception)
    		{    
    		}
    	}
    }
