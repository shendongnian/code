    var list = new[] { 1, 2, 3, 4, 5, 11, 11, 12, 13, 3, 5, 6, 11, 22, 12, 24, 5, 6, 22, 33 };
    
    var result = list.Aggregate(new List<List<int>> { new List<int>() }, (lst, ele) =>
    {
        var cur = lst.Last();
        if (ele < 10)
            if (cur.Count > 3)
                lst.Add(new List<int>());
            else
                cur.Clear();
        else
            cur.Add(ele);
        
        return lst;
    });
    if (result.Last().Count <= 3)
        result.RemoveAt(result.Count-1);
