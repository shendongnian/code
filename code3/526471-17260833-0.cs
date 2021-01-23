    TreeNode LastClickedTreeNode;
    private void customTreeViewSql_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        // update last treenode clicked.
        LastClickedTreeNode = e.Node;
    }
    private void toolStripMenuDeleteAll_Click(object sender, EventArgs e)
    {
        foreach (TreeNode n in LastClickedTreeNode.Nodes)
            n.Remove();
    }
