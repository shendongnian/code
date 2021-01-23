        //We First declare a recursive method to loop through all nodes, 
    //we need to pass a root node to start 
        private void ScanNodes(TreeNode parent)
                {
                    foreach (TreeNode node in parent.Nodes)
                    {
                        if (node.Checked)
                        {
                            nodeList.Add(node.Text);
                        }
                        if (node.Nodes.Count > 0)
                        {
                            ScanNodes(node);
                        }
                    }
                }
