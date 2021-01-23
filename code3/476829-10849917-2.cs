    if (myDictionary.Keys.Count > 0)
    {
      var conditions = myDictionary.Keys.Select((key, idx) => string.Format("{0} (@{1})", key, idx));
    
      // in .NET 4, the ToArray() part can go away
      predicateString = string.Join(" and ", conditions.ToArray());
      predicateValues = myDictionary.Values.ToArray();
    }
