    public void CheckAllNodes(TreeNodeCollection nodes)
    {
        foreach (TreeNode node in nodes)
        {
            node.Checked = true;
            CheckChildren(node, true);
        }
    }
    
    public void UncheckAllNodes(TreeNodeCollection nodes)
    {
        foreach (TreeNode node in nodes)
        {
            node.Checked = false;
            CheckChildren(node, false);
        }
    }
    
    private void CheckChildren(TreeNode rootNode, bool isChecked)
    {
        foreach (TreeNode node in rootNode.Nodes)
        {
            CheckChildren(node, isChecked);
            node.Checked = isChecked;
        }
    }
