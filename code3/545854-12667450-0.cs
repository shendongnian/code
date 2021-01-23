    bool testIfCharactersAreUnique(string key)
    {
    	string table = "";
    	string result = "";
    	foreach (char value in key)
    	{
    		if (table.IndexOf(value) == -1)
    		{
    			table += value;
    			result += value;
    		}
    	}
    	return result.Length == key.Length;
    }
