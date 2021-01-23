    public static IEnumerable<string> GetXMLFiles(string directory)
    {
    	List<string> files = new List<string>();
    
    	try
    	{
            files.AddRange(Directory.GetFiles(directory, "*.xml", SearchOption.AllDirectories));
    	}
    	catch (Exception ex)
    	{
    		Console.WriteLine(ex.Message);
    	}
    
    	return files;
    }
