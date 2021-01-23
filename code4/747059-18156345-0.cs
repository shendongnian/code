    var originalList = new List<string>(){"split","1","split","2","2","split","3","3","3"};
    var result = new List<List<string>>();
    List<string> subList = new List<string>();
    foreach(string str in originalList)
    {
        if(str=="split")
        {
            subList = new List<string>();
            result.Add(subList);
        }
        subList.Add(str);
    }
