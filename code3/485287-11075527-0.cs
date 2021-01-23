     private void PopulateFolderTreeView(string directories, TreeNode parentNode)
                {
                    string[] directoriesArray = Directory.GetDirectories(directories);
                    string[] filesArrays = Directory.GetFiles(directories);
                    if (directoriesArray.Length != 0)
                    {
                        foreach (string currentDirectory in directoriesArray)
                        {
                            TreeNode myNode = new TreeNode(Path.GetFileNameWithoutExtension(currentDirectory));
                            if (parentNode == null)
                            {
                                treeView1.Nodes.Add(myNode);
                            }
                            else
                            {
                                parentNode.Nodes.Add(myNode);
                            }
                            PopulateFolderTreeView(currentDirectory, myNode);
                        }
        
                    }
                    if (filesArrays.Length != 0)
                    {
                        foreach (string currentFile in filesArrays)
                        {
                            TreeNode myNode = new TreeNode(Path.GetFileName(currentFile));
                            if (parentNode == null)
                            {
                                treeView1.Nodes.Add(myNode);
                            }
                            else
                            {
                                parentNode.Nodes.Add(myNode);
                            }
                            //PopulateTreeView(currentDirectory, myNode);
                        }
        
                    }
                }
    
     
    
         private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
                {
                    foreach (TreeNode node in treeNode.Nodes)
                    {
                        node.Checked = nodeChecked;
                        if (node.Nodes.Count > 0)
                        {
                            // If the current node has child nodes, call the
                            // CheckAllChildNodes method recursively.
                            CheckAllChildNodes(node, nodeChecked);
                        }
                    }
                }
        
                private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
                {
                    // The code only executes if the user caused the checked state to change.
                    if (e.Action == TreeViewAction.ByMouse)
                    {
                        if (e.Node.Nodes.Count > 0)
                        {
                            // Calls the CheckAllChildNodes method, passing in the current
                            // checked value of the TreeNode whose checked state changed.
                            CheckAllChildNodes(e.Node, e.Node.Checked);
                        }
                    }
        
                }
