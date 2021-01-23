    // testing for duplicates
    List<Dictionary<string, object>> duplicates = new List<Dictionary<string, object>>();
    List<string> index = new List<string>();
    foreach (var value in values)
    {
    	List<string> keyValues = new List<string>();
    	foreach (string key in keys)
    	{
    		keyValues.Add(value[key].GetHashCode().ToString());
    	}
    	string hash = string.Join(",", keyValues.ToArray());
    	if (index.Contains(hash))
    		duplicates.Add(value);
    	else
    		index.Add(hash);
    }
    
    var cleanList = values.Except(duplicates);
