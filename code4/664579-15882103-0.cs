    Dictionary<string, List<Dictionary<string, int>>> MyList = 
        new Dictionary<string, List<Dictionary<string, int>>>();
    foreach (int i in Enumerable.Range(1, 100))
    {
        var list = new List<Dictionary<string, int>>();
        foreach (int ii in Enumerable.Range(1, 100))
            list.Add(new Dictionary<string, int>() { { "Item " + ii, ii } });
        MyList.Add("Item " + i, list);
    }
