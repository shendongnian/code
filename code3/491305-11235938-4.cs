    public void IncrementFix()
    {
    	var dictionary2 = dictionary;
    	//in another thread: dictionary = new Dictionary<int, int>();
    	//this is OK, dictionary2 is still pointing to the ORIGINAL dictionary
    	int newValue = dictionary2[0] + 1;
    	dictionary2[0] = newValue;
    }
