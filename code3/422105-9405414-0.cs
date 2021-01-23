    List<List<string>> lists = //whatever
    HashSet<string> set = new HashSet<string>(lists[0]);
    
    for(int i = 1; i < lists.Count; i++)
    {
        set.IntersectWith(lists[i]);
    }
