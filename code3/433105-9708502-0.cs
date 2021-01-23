    // testing for duplicates
    List<Dictionary<string, object>> duplicates = new List<Dictionary<string, object>>();
    List<string> index = new List<string>();
    foreach (var value in values)
    {
    	string hash = string.Join(",", value.Where(v => keys.Contains(v.Key)).Select(v => v.Value.GetHashCode().ToString()).ToArray());
    	if (index.Contains(hash))
    		duplicates.Add(value);
    	else
    		index.Add(hash);
    }
    
    var cleanList = values.Except(duplicates);
