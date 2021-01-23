    foreach (string s in hostnames)
    {
        TreeNode newNode = new TreeNode(s);
        hostView.SelectedNode.Nodes.Add(newNode);
        TabPage myTabPage = new TabPage(s);
        myTabPage.Name = "Name you want to set";
        tabControl1.TabPages.Add(myTabPage);
    }
