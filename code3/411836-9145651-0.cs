    private void treeView1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TreeView tv = (TreeView)sender;
            
            TreeViewItem child = (TreeViewItem)tv.SelectedItem;
            if (child.Parent.GetType() == typeof(TreeViewItem)) // verify that parent is TreeViewItem
            {
                TreeViewItem parent =(TreeViewItem)child.Parent; 
                string text = parent.Header.ToString();
            }
            
        }
