    Node MakeTree()
    {   
        // create root, build subtree and return it
        var node = new Node() {Id = 0, ParentId = -1};
        MakeSubTree(node);
        return node;
    }
    void MakeSubTree(Node parentNode)
    {
        // find all children of parent node (they have parentId = id of parent node)
        var nodes = TableItems.Where(e => e.ParentId == parentNode.Id)
                        .Select(e => new Node {ParentId = e.ParentId, Id = e.Id});
        // build subtree for each child and add it in parent's children collection
        foreach (var node in nodes)
        {
            MakeSubTree(node);
            parentNode.Children.Add(node);             
        }
    }
