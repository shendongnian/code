    private int TreeviewCountCheckedNodes(TreeNodeCollection treeNodeCollection)
            {
                int countchecked = 0;
                if (treeNodeCollection != null)
                {
                    foreach (TreeNode node in treeNodeCollection)
                    {
                        if (node.Nodes.Count == 0 && node.Checked)
                        {
                            countchecked++;
                        }
                        else if (node.Nodes.Count > 0)
                        {
                            countchecked += TreeviewCountCheckedNodes(node.Nodes);
                        }
                    }
                }
                return countchecked;
            }
