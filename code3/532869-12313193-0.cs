    Dictionary<string, int> dictionary = new Dictionary<string, int>();
    dictionary["cat"] = 1;
    dictionary["dog"] = 4;
    dictionary["mouse"] = 2;
    dictionary["rabbit"] = -1;
    
    // Call ToList.
    List<KeyValuePair<string, int>> list = dictionary.ToList();
    
    // Loop over list.
    foreach (KeyValuePair<string, int> pair in list)
    {
    	Console.WriteLine(pair.Key);
    	Console.WriteLine("   {0}", pair.Value);
    }
