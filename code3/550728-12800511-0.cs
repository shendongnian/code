    Dictionary<string, int> dictionary =
	    new Dictionary<string, int>();
	dictionary.Add("cat", 2);
	dictionary.Add("dog", 1);
	dictionary.Add("llama", 0);
	dictionary.Add("iguana", -1);
    // Acquire keys and sort them.
	var list = dictionary.Keys.ToList();
	list.Sort();
