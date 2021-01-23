    var list1 = new List<int>() { 1, 2, 3, 4 };
    var list2 = new List<int>() { 2, 3, 5, 6,7, 8 }; 
    var list3 = new List<int>() { 3, 4, 5 };
    var all = new List<List<int>>() { list1, list2, list3 };
    int min = all.Min(l => l.Min());
    var max = all.Max(l => l.Max());
    List<int> allValues = new List<int>(max - min + 1);
    allValues.AddRange(Enumerable.Range(min, max - min + 1));
  
    List<int?> l1Result = new List<int?>(allValues.Count);
    List<int?> l2Result = new List<int?>(allValues.Count);
    List<int?> l3Result = new List<int?>(allValues.Count);
    for (int i = 0; i < allValues.Count; i++)
    {
        var nextVal = allValues[i];
        if (list1.BinarySearch(nextVal) >= 0)
            l1Result.Add(nextVal);
        else
            l1Result.Add(new Nullable<int>());
        if (list2.BinarySearch(nextVal) >= 0)
            l2Result.Add(nextVal);
        else
            l2Result.Add(new Nullable<int>());
        if (list3.BinarySearch(nextVal) >= 0)
            l3Result.Add(nextVal);
        else
            l3Result.Add(new Nullable<int>());
    }
