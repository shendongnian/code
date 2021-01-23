    Dictionary<int, B> bDict = new Dictionary<int, B>();
    foreach (B b in bList) bDict.Add(b.Common, b);
    foreach (A a in aList) {
      if (bDict.ContainsKey(a.Common)) 
        bDict[a.Common].bValue = a.aValue;
    }
      
