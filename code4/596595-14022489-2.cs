    private bool skipEvents = false; // this flag to avoid infinite recursion
    void treeView1_BeforeCheck(object sender, TreeViewCancelEventArgs e)
    {
        // if is a root (car or shoes), or it's a recursive call, just return
        if (skipEvents || e.Node.Parent == null) 
            return;
        skipEvents = true;
        foreach (TreeNode sibling in e.Node.Parent.Nodes)
        {
            // set the other siblings to unchecked
            if (sibling != e.Node)
                sibling.Checked = false;
        }
        skipEvents = false;
    }
