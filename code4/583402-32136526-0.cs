    int checkedNodesCount = 0;
    private int GetCheckedNodesCount(TreeNodeCollection treeNodeCollection)
        {
            
            TreeNode node = treeNodeCollection[0];
            
            if (node != null)
            {
                if (node.Nodes.Count > 0)
                {
                    foreach (TreeNode childnode in node.Nodes)
                    {
                        if (childnode.Nodes.Count == 0 && childnode.Checked)
                        {
                            checkedNodesCount++;
                        }
                        else if (childnode.Nodes.Count > 0)
                        {
                            checkedNodesCount += GetCheckedNodesCount(childnode.Nodes);
                        }
                    }
                }
                else
                {
                    if (node.Checked)
                    {
                        checkedNodesCount++;
                    }
                }
            }
            return checkedNodesCount;
        }
