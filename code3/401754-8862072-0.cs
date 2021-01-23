    private void SetupHostTree()
    {
        // Set internal host names
        using (var reader = File.OpenText("Configuration.ini"))
        {
            List<string> hostnames = ParseInternalHosts(reader).ToList();
            foreach (string s in hostnames)
            {
                // Ensure that a node is currently selected
                TreeNode selectedNode = hostView.SelectedNode;
                if (selectedNode != null)
                {
                    TreeNode newNode = new TreeNode(s);
                    selectedNode.Nodes.Add(newNode);
                }
                else
                {
                    // maybe do nothing, or maybe add the new node to the root
                }
    
                string title = s;
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = s;
                tabControl1.TabPages.Add(myTabPage);
            }
        }
    }
