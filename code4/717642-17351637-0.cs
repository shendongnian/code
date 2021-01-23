    Dictionary<string, int> dropsDict = new Dictionary<string, int>();
    .
    .
    .
    if (a.Contains(mobName) && a.Contains("drops"))
    {
        string lastpart = a.Substring(a.LastIndexOf("drops"));
        string modifiedLastpart = lastpart.Remove(0, 6);
        
        if (dropsDict.ContainsKey(modifiedLastpart)) 
        {
            dropsDict[modifiedLastpart] = dropsDict[modifiedLastpart]++;
        } 
        else 
        {
            dropsDict[modifiedLastpart] = 1;
        }
    }
