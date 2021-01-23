        TreeView treeView = new TreeView();
        TreeNode parentNode = treeView.SelectedNode;
        if (parentNode.GetNodeCount(true) > 0)
        {
            foreach (TreeNode childNodes in parentNode.Nodes)
            {
                //// do stuff with nodes.
            }
        }
