    Node MakeTree()
    {
        var node = new Node() {Id = 0, ParentId = -1};
        MakeSubTree(node);
        return node;
    }
    void MakeSubTree(Node parentNode)
    {
        var nodes = TableItems.Where(e => e.ParentId == parentNode.Id)
                        .Select(e => new Node {ParentId = e.ParentId, Id = e.Id})
        parentNode.Children.AddRange(nodes);
        foreach (var node in nodes)
        {
            MakeSubTree(node);
        }
    }
