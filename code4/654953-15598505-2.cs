    //Create global dictionary of lists
    Dictionary<string, List<string> dictionaryOfLists = new Dictionary<string, List<string>();
    
    //Get and create lists from a single method
    public List<string> FindListByName(string stringListName)
    {
        //If the list we want does not exist yet we can create a blank one
        if (!dictionaryOfLists.ContainsKey(stringListName))
            dictionaryOfLists.Add(stringListName, new List<string>());
        //Return the requested list
        return dictionaryOfLists[stringListName];
    }
