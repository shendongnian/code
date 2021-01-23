    private void CreateGroup2(NavBarGroup navBarGroup)
    {
        System.Windows.Controls.TreeView treeview = new System.Windows.Controls.TreeView();
        TreeViewItem nod = new TreeViewItem();
        nod.Header = "Tree Node1";
        treeview.Items.Add(nod);
        TreeViewItem nod1 = new TreeViewItem();
        nod1.Header = "Tree Node2";
        treeview.Items.Add(nod1);
        TreeViewItem nod2 = new TreeViewItem();
        nod2.Header = "Tree Node3";
        nod1.Items.Add(nod2);
        //StackPanel stcPnl = new StackPanel(); /optiona
        //stcPnl.Children.Add(treeview);
        //navBarGroup.Content = stcPnl;
	    navBarGroup.Content = treeview;
        navBarGroup.DisplaySource = DisplaySource.Content;
    }
