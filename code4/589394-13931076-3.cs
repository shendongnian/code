    /// <summary>
    /// Recursive function to add node
    /// </summary>
    /// <param name="tnbase">RootNode</param>
    /// <param name="tn">Node to be added</param>
    private void AddNode(TreeNode tnbase, TreeNode tn)
    {
        bool exists = false;
        foreach (TreeNode rt in tnbase.Nodes)
        {
            if (this.IsNodesEquals(rt, tn))
            {
                foreach (TreeNode srt in tn.Nodes)
                {
                    this.AddNode(rt, srt);
                }
                exists = true;
            }
        }
        if (!exists)
        {
            tnbase.Nodes.Add(tn);
        }
    }
    /// <summary>
    /// Get exist node from the treeview
    /// </summary>
    /// <param name="tv">Treeview to check</param>
    /// <param name="tn">Node to compare</param>
    /// <returns></returns>
    private TreeNode ExistNode(TreeView tv, TreeNode tn)
    {
        TreeNode existsnote = null;
        foreach (TreeNode rt in tv.Nodes)
        {
            if (this.IsNodesEquals(rt, tn))
            {
                existsnote = rt;
            }
        }
        return existsnote;
    }
    /// <summary>
    /// Compare two nodes by the text
    /// </summary>
    /// <param name="t1">node to compare</param>
    /// <param name="t2">node to compare with</param>
    /// <returns></returns>
    private bool IsNodesEquals(TreeNode t1, TreeNode t2)
    {
        return (t1 != null && t2 != null && t1.Text == t2.Text);
    }
