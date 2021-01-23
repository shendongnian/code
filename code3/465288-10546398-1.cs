    public IEnumerable<int> FindAllIndexes(string str, string pattern)
    {
    	int prevIndex = -pattern.Length; // so we start at index 0
    	int index;
    	while((index = str.IndexOf(pattern, prevIndex + pattern.Length)) != -1)
    	{
    		prevIndex = index;
    		yield return index;
    	}
    }
    
    string str = "45##78$$#56$$JK01UU";
    string pattern = "##";
    
    var indexes = FindAllIndexes(str, pattern);
