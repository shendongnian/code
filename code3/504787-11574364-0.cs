    tree1.AfterSelect += new TreeViewEventHandler(tree_AfterSelect);
    tree2.AfterSelect += new TreeViewEventHandler(tree_AfterSelect);
    
    public void tree_AfterSelect(object sender, TreeViewEventArgs e)
    {
        button1.Visible = tree1.SelectedNode != null && tree2.SelectedNode != null;
    }
