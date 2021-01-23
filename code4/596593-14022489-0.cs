        private bool skipEvents = false; // this flag to avoid recursion
        void treeView1_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (skipEvents || e.Node.Parent == null) // if is a root (car or shoes)
                return;
            skipEvents = true;
            foreach (TreeNode sibling in e.Node.Parent.Nodes)
                sibling.Checked = false;
            skipEvents = false;
        }
