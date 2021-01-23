    public static int GetIndex(Dictionary<string, object> dictionary, string key) 
	{
		for (int index = 0; index < dictionary.Count; index++)
		{
			if(dictionary.Skip(index).First().Key == key)
				return index;
		}
	
		return -1;
	}
