     foreach (string s in hostnames)
            {
                TreeNode newNode = new TreeNode(s);
                hostView.SelectedNode.Nodes.Add(newNode);
    
                string title = s;
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = "Name you want to set";
                tabControl1.TabPages.Add(myTabPage);
            }
