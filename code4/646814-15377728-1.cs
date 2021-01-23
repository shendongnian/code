    static Dictionary<int, string> getDBList(string DBname)
    {
        Dictionary<int, string> WordsDictionary = new Dictionary<int, string>();
        string[] files;
    
        try
        {
            files = Directory.GetFiles(@"dbase/", DBname);
            foreach (string file in files)
                foreach (string line in File.ReadAllLines(file))
                {
                     string data = line.Trim().ToUpperInvariant();
                     int hash = data.GetHashCode();
    
                     if(!WordsDictionary.ContainsKey(hash))
                         WordsDictionary.Add(hash, data);					
                }
            }
	
        catch (Exception ex)
    	{
    		Console.WriteLine(ex.ToString());
    		return new Dictionary<int, string>();
    	} 
        return WordsDictionary;
    }
    
    static bool SearchText(string text, Dictionary<int, string> WordsDictionary)
    {
    	int hash = text.Trim().ToUpperInvariant().GetHashCode();
    
    	if (WordsDictionary.ContainsKey(hash))
    		return true;
    	else
    		return false;
    }
