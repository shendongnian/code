    Dictionary<string, List<String> DictionaryOfLists = new Dictionary<string, List<String>();
    
    public void AddList(List<string> listToAdd, stringListName)
    {
        DictionaryOfLists.Add(stringListName, listToAdd);
    }
    
    public List<string> findListByName(string stringListName)
    {
        return DictionaryOfLists[stringListName];
    }
