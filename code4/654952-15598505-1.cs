    //Create global dictionary of lists
    Dictionary<string, List<string> DictionaryOfLists = new Dictionary<string, List<string>();
    
    //Get and create lists from a single method
    public List<string> findListByName(string stringListName)
    {
        //If the list we want does not exist yet we can create a blank one
        if (!DictionaryOfLists.ContainsKey(stringListName))
            DictionaryOfLists.Add(stringListName, new List<string>());
        //Return the requested list
        return DictionaryOfLists[stringListName];
    }
