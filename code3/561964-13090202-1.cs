    void ConcatString(string prefix, int index, List<List<string>> collection, List<string> output)
    {
    	if(index == collection.Count)
    	{
    		output.Add(prefix);
    		return;
    	}
    	var subCollection = collection[index];
    	foreach(var str in subCollection)
    	{
    		string newPrefix = ((prefix.Length > 0)? "---" : "") + str;
    		ConcatString(newPrefix, index+1, collection, output);
    	}
    }
