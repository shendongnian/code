     private void cmdMoveRight_Click(object sender, EventArgs e)
        {
            tvSelectedItems.TreeView.Nodes.Clear();
            // Traverse first level Tree Nodes
            foreach (TreeNode originalNode in tvDirectory.Nodes)
            {
                TreeNode newNode = new TreeNode(originalNode.Text);
                newNode.Name = originalNode.Name;
                newNode.Tag = originalNode.Tag;
                newNode.Checked = originalNode.Checked;
                //Only add to the new treeview if the node is checked
                if (originalNode.Checked)
                {
                    tvSelectedItems.TreeView.Nodes.Find(originalNode.Parent.Name,true)[0].Nodes.Add(newNode);
                }
                //Start recursion - this will be called for each first level node - there should technically only be 1 "ROOT" node.
                IterateTreeNodes(originalNode, newNode);
            }
            
        }
        private void IterateTreeNodes(TreeNode originalNode, TreeNode rootNode)
        {
            //Take the node passed through and loop through all children
            foreach (TreeNode childNode in originalNode.Nodes)
            {
                // Create a new instance of the node, will need to add it to the recursion as a root item 
                // AND if checked it needs to get added to the new TreeView.
                TreeNode newNode = new TreeNode(childNode.Text);
                newNode.Tag = childNode.Tag;
                newNode.Name = childNode.Name;
                newNode.Checked = childNode.Checked;
                if (childNode.Checked)
                {
                    // Now we know this is checked, but what if the parent of this item was NOT checked. 
                    //We need to head back up the tree to find the first parent that exists in the tree and add the hierarchy.
                      TreeNode[] nodestest = tvSelectedItems.TreeView.Nodes.Find(childNode.Parent.Name, true);
                      if (nodestest.Length > 0)
                      {
                          tvSelectedItems.TreeView.Nodes.Find(childNode.Parent.Name,true)[0].Nodes.Add(newNode);
                      }
                      else
                      {
                          AddParents(childNode);// Find the parent(s) and add them to the tree with their CheckState matching the original node's state
                          
                      }
                }
                //recurse
                IterateTreeNodes(childNode, newNode);
            }
        }
        
        private void AddParents(TreeNode node)
        {
            
            if (node.Parent != null)// Check if parent is null (would mean we're looking at the root item
            {
                TreeNode[] nodestest = tvSelectedItems.TreeView.Nodes.Find(node.Parent.Name, true);
                if (nodestest.Length > 0)
                {
                   
                    TreeNode[] nodes = tvDirectory.Nodes.Find(node.Name, true);
                    TreeNode newNode = new TreeNode(nodes[0].Text);
                    newNode.Name = nodes[0].Name;
                    newNode.Tag = nodes[0].Tag;
                    newNode.Checked = nodes[0].Checked;
                    tvSelectedItems.TreeView.Nodes[node.Parent.Name].Nodes.Add(newNode);
                }
                else
                {
                    AddParents(node.Parent);
                    
                    TreeNode newNode = new TreeNode(node.Text);
                    newNode.Name = node.Name;
                    newNode.Tag = node.Tag;
                    newNode.Checked = node.Checked;
                    tvSelectedItems.TreeView.Nodes.Find(node.Parent.Name,true)[0].Nodes.Add(newNode);
                    
                }
            }
            else // deal with root node
            {
                TreeNode rootNode = new TreeNode(node.Text);
                rootNode.Name = node.Name;
                rootNode.Tag = node.Tag;
                rootNode.Checked = node.Checked;
                tvSelectedItems.TreeView.Nodes.Add(rootNode);
            }
            
        }
