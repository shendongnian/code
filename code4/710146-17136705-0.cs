    Dictionary<int, List<Data>> intData = new Dictionary<int, List<Data>>();
    foreach (var iVal in index)
    {
         List<Data> tmpList = new List<Data>();
         if (data.TryGetValue(iVal.Value, out tmpList))
         {
             intData.Add(iVal.Key, tmpList);
         }
    }
