    private void TreeViewBeforeExpand(object sender, TreeViewCancelEventArgs e)
    {
        foreach (TreeNode node in e.Node.Parent.Nodes)
        {
            if(node != e.Node)
                node.Collapse();
        }
    }
