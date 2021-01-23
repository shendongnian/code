    Dictionary<int, List<string>> likeListDict = new Dictionary<int, List<string>>();
    List<string> lists = new List<string>();
    
    lists.Add("hello");
    lists.Add("world");
    
    likeListDict.Add(1, lists);
    
    lists = new List<string>();
    
    lists.Add("foobar");
    
    likeListDict.Add(2, lists);
