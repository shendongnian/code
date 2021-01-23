    Dictionary<string, Data> aItems = listA.ToDictionary(x => x.Key);
    Dictionary<string, Data> bItems = listb.ToDictionary(x => x.Key);
    
    foreach(Data a in aItems.Values)
    {
      if (!bItems.ContainsKey(a.Key))
      {
        listA.Remove(a); //O(n)  :(
      }
      else
      {
        a.Value = bItems[a.Key].Value;
      }
    }
    
    foreach(Data b in bItems.Values)
    {
      if (!aItems.ContainsKey(b.Key)
      {
        listA.Add(b);
      }
    }
