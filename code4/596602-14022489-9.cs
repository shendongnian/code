    private bool skipEvents = false; // this flag to avoid infinite recursion
    void treeView1_BeforeCheck(object sender, TreeViewCancelEventArgs e)
    {
        // if it's a recursive call, just return
        if (skipEvents)
            return;
        skipEvents = true;
        // it's a root (e.g. car or shoes) 
        if (e.Node.Parent == null)
        {
            // if root node is going to be checked, just cancel the action (i.e. block parent selection)
            if (!e.Node.Checked)
            {
                    
                e.Cancel = true;
            }
        }
        else
        {
            foreach (TreeNode sibling in e.Node.Parent.Nodes)
            {
                // set the other siblings to unchecked
                if (sibling != e.Node)
                    sibling.Checked = false;
            }
        }
        skipEvents = false;
    }
    void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
    {
        // if it's a recursive call, just return
        if (skipEvents)
            return;
        this.skipEvents = true;
        // it's a root (e.g. car or shoes) 
        if (e.Node.Parent == null)
        {
            // root node has been unchecked, so uncheck the children
            if (!e.Node.Checked)
            {
                foreach (TreeNode child in e.Node.Nodes)
                    child.Checked = false;
            }
        }
        else
        {
            // if a child node has been checked --> check the parent
            // otherwise, uncheck the parent
            e.Node.Parent.Checked = e.Node.Checked;
        }
        this.skipEvents = false;
    }
