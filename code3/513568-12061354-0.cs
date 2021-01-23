    ChangeCheckedChildren(e.Node, e.Node.Checked);
    ChangeCheckedParents(e.Node, e.Node.Checked);
     /// <summary>
            /// Recursively checks or unchecks all child nodes for a given TreeNode.
            /// </summary>
            /// <param name="node">TreeNode to check or uncheck.</param>
            /// <param name="check">Desired value of TreeNode.Checked.</param>
            private void ChangeCheckedChildren(TreeNode node, bool check)
            {
    
                try
                {
                // "Queue" up child nodes to be checked or unchecked.
                if (node.ChildNodes.Count > 0)
                {
                    for (int i = 0; i < node.ChildNodes.Count; i++)
                        ChangeCheckedChildren(node.ChildNodes[i], check);
                }
                node.Checked = check;
                }
    
    
                catch (Exception ex)
                {
    
                }
               
            }
    
            /// <summary>
            /// Recursively checks or unchecks all parent nodes for a given TreeNode.
            /// </summary>
            /// <param name="node">TreeNode to check or uncheck.</param>
            /// <param name="check">Desired value of TreeNode.Checked.</param>
            private void ChangeCheckedParents(TreeNode node, bool check)
            {
                try
                {
    
                    if (node.Parent == null)  // if we are at the root node
                    {
                        if (node.ChildNodes.Count > 0)
                        {
                            for (int i = 0; i < node.ChildNodes.Count; i++)
                            {
                                if (node.ChildNodes[i].Checked == true)
                                {
                                    node.Checked = true;
                                    return;
                                }
                            }
                            node.Checked = false;
                        }
                        else
                        {
                            node.Checked = check;
                        }
    
                    }
                else
                {
                    // Check all parents if the user is checking
                    if (check == true)
                    {
                        node.Checked = check;
                        ChangeCheckedParents(node.Parent, check);
                    }
    
                    else
                    {
                        // Do not uncheck a parent if any of its other children or their children are checked
                        if (node.ChildNodes.Count > 0)
                        {
                            // Default to not check and check if required
                            node.Checked = false;
                            for (int i = 0; i < node.ChildNodes.Count; i++)
                            {
                                if (node.ChildNodes[i].Checked == true)
                                {
                                    node.Checked = true;
                                }
                            }                            
                                ChangeCheckedParents(node.Parent, check);
                        }
                        else
                        {
                            node.Checked = check;
                            ChangeCheckedParents(node.Parent, check);
                        }
                    }
                }
                }
    
                catch (Exception ex)
                {
    
    
                }
    
    
              
            }
