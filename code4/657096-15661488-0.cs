    Dictionary<IComparable, List<Node>> nodes = new Dictionary<IComparable, List<Node>>();
    foreach(var node in ListOfAllNodes)
    {
        if(!nodes.ContainsKey(node.ParentId)){
            nodes.Add(node.ParentId, new List<Node>());
        }
        nodes[node.ParentId].Add(node);
    }
