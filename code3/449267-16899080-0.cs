        private bool allowExpandCollapse = false;
        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            e.Cancel = !allowExpandCollapse;
        }
        private void treeView1_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            e.Cancel = !allowExpandCollapse;
        }
        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                e.Cancel = true;
            }
        }
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                allowExpandCollapse = true;
                if (e.Node.IsExpanded)
                {
                    TreeNode selectedNode = treeView1.SelectedNode;
                    e.Node.Collapse();
                    allowExpandCollapse = false;
                    treeView1.SelectedNode = selectedNode;
                }
                else
                {
                    e.Node.Expand();
                    allowExpandCollapse = false;
                }
            }
        }
