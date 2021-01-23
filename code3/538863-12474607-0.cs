    private Dictionary<string, List<<string>> dictionary = 
        new Dictionary<string, List<<string>>();
    
    //fill that dictionary
    ...
    
    //get list from a dictionary by list id
    public List getList(string listId) 
    {
    	return dictionary[listId];
    }
