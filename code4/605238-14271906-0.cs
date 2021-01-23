    Hierarchy CreateTree(IEnumerable<Hierarchy> Nodes)
    {
        var idToNode = Nodes.ToDictionary(n => n.ID, n => n);
        
        Hierarchy root;
        foreach (var n in Nodes)
        {
            if (n.ID == null)
            {
                if (root != null)
                {
                    //there are multiple roots in the data
                }
                root = n;
                continue;
            }
            Hierarchy parent;
            if (!idToNode.TryGetValue(n.ID, parent))
            {
                //Parent doesn't exist, orphaned entry
            }
            parent.Children.Add(n);
        }
    
        if (root == null)
        {
            //There was no root element
        }
        return root;
    }
