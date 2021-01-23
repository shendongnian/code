    public IEnumerable<String> ReadLinesInDirectory(string path)
    {
    	return Directory.EnumerateFiles(path)
    	                .SelectMany(f => 
    					    File.ReadLines(f)
    						.AsEnumerable()
    						.Skip(1));
    }
