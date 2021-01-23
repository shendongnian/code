    String GetSelectedItemPath()
    {
        String path = String.Empty;
        // See if a node is selected in the TreeView
        TreeNode selectedNode = TreeView1.SelectedNode;
        if (selectedNode != null)
        {
            // Also check that an item is selected in the ListView
            ListViewItem item = ListView1.SelectedItems[0];
            if (item != null)
            {
                // Build the full path to the selected item.
                path = selectedNode.FullPath + TreeView1.PathSeparator + item.Text;
            }
        }
        return path;
    }
