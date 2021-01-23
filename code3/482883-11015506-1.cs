    public void traverse(TreeNode t)
    {
        for (int i = t.Nodes.Count-1; i >= 0; i--)
        {
            traverse(t.Nodes[i]);
        }
        /*Do something*/
    }
