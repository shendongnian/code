    public IEnumerable<TreeNode> AddSomeNodes()
    {
        TreeNode node = new TreeNode();
        node.Nodes.Add(new TreeNode());
        yield return node;
    }
