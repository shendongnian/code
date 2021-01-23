    List<MyClass> list = ...
    var nodes = list.Select(x => new Node<long, MyClass>
                                     {
                                         Key = x.MyKey,
                                         ParentKey = x.MyParentKey,
                                         Data = x
                                     }).ToList();
    var startNode = nodes.FirstOrDefault(x => x.Data.Stuff == "Pick me!");
    var tree = BuildTree(nodes, startNode);
