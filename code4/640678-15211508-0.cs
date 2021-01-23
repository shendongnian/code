    List<MyObject2> result = new List<MyObject2>(){new MyObject2(1, 0)};
    Dictionary<int, List<MyObject2>> dict = new Dictionary<int, List<MyObject2>>();
    foreach (MyObject1 obj1 in list)
    {
        MyObject2 tmp = new MyObject2(obj1.Id, obj1.ParentId);
        if (!dict.ContainsKey(tmp.ParentId))
        {
            dict.Add(tmp.ParentId, new List<MyObject2>());
        }
        dict[tmp.ParentId].Add(tmp);
        result.Add(tmp);
    }
    foreach (MyObject2 obj2 in result)
    {
        obj2.Children = dict.ContainsKey(obj2.Id) ? dict[obj2.Id] : new List<MyObject2>();
    }
