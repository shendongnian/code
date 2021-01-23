    private object FindNode(TreeNode node)
    {
        object tag = null;
        if (node.Nodes != null && node.Nodes.Count > 0)
        {
             tag = FindNode();
        }
        
        if (myString.Contains(node.Text))
        {
             return node.Tag;
        }
        return tag;
    }
