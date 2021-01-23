    private void FileTreeView_AfterExpandobject sender, TreeViewEventArgs e)
    {
        // Calls the CheckAllChildNodes method, passing in the current
        // checked value of the TreeNode whose checked state changed.
        CheckAllChildNodes(e.Node, e.Node.Checked);        
    }
    
