    int min = all.Min(l => l.Min());
    var max = all.Max(l => l.Max());
    int count = max - min + 1;
    List<int?> l1Result = new List<int?>(count);
    List<int?> l2Result = new List<int?>(count);
    List<int?> l3Result = new List<int?>(count);
    foreach (int val in Enumerable.Range(min, count))
    {
        if (list1.BinarySearch(val) >= 0)
            l1Result.Add(val);
        else
            l1Result.Add(new Nullable<int>());
        if (list2.BinarySearch(val) >= 0)
            l2Result.Add(val);
        else
            l2Result.Add(new Nullable<int>());
        if (list3.BinarySearch(val) >= 0)
            l3Result.Add(val);
        else
            l3Result.Add(new Nullable<int>());
    }
