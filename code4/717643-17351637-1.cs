    Dictionary<string, int> dropsDict = new Dictionary<string, int>();    
    
    foreach (string line in lines.Where(l => l.Length >= 5))
    {
         string a = line.Remove(0, 11);
         if ((a.Contains(mobName) && a.Contains("dies")))
         {
             mobDeathCount++;
         }
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
    }
