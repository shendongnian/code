    list1.Sort();
    list2.Sort();
    var result = new List<string>();
    for(int i=0, j=0; i<list1.Count; i++)
    {
        var l1Val = list1[i];
        for (; j < list2.Count && string.CompareOrdinal(l1Val, list2[j]) > 0; j++) ;
        for (; j < list2.Count && list2[j].StartsWith(l1Val); j++)
        {
            result.Add(list2[j]);
        }
    }
