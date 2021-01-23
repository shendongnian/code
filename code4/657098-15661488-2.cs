    Dictionary<IComparable, List<Node>> nodes = new Dictionary<IComparable, List<Node>>();
    Node parentNode = null;
    foreach(var node in ListOfAllNodes)
    {
        if(node.ParentId == null)
        {
            parentNode = node;
        }else
        {
            if(!nodes.ContainsKey(node.ParentId)){
               nodes.Add(node.ParentId, new List<Node>());
            }
            nodes[node.ParentId].Add(node);
        }
    }
