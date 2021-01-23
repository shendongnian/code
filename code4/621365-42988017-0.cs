        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }
        private void treeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Nodes.Count > 0)
                {
                    if (!e.Node.Checked)
                    {
                        this.CheckAllChildNodes(e.Node, e.Node.Checked);
                    }
                }
            }
            if (e.Node.Parent != null)
            {
                TreeNode n = e.Node;
                while (n.Parent != null)
                {
                    if (n.Checked)
                    {
                        n.Parent.Checked = true;
                    }
                    n = n.Parent;
                }
            }
        }
