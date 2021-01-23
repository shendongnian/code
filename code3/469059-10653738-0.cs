    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    {
        TreeNode tnode = new TreeNode(ds.Tables[0].Rows[i][1].ToString());
        tnode.SelectAction = TreeNodeSelectAction.Expand;
        // Add the new TreeNodes underneath the currently selected TreeNode.
        TreeView1.SelectedNode.ChildNodes.Add(tnode);
    }
    TreeView1.SelectedNode.Expand();
