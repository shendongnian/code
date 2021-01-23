    var list = new NodeList();
    // adding
    list.Add(3, new NodeInfo() { Info = "some info 3" });
    // inserting
    for (int i = 0; i < 100000; i++)
    {
        list.Add(1, new NodeInfo() { Info = "some info 1" });
        list.Add(2, new NodeInfo() { Info = "some info 2" });
        list.Add(1, new NodeInfo() { Info = "some info 1.1" });
    }
    // retrieving the first item
    var firstNodeInfo = list.FirstNode();
    // retrieving an item
    var someNodeInfo = list[2].First();
