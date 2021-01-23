    private static int getCaseInvariantIndex(List<string> ItemsList, string searchItem)
    {
        List<string> lowercaselist = new List<string>();
    
        foreach (string item in ItemsList)
        {
            lowercaselist.Add(item.ToLower());
        }
    
        return lowercaselist.IndexOf(searchItem.ToLower());
    }
