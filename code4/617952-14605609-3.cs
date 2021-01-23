    private void button4_Click(object sender, EventArgs e)
            {
                //saving expanded nodes
                List<string> ExpandedNodes = new List<string>();
                ExpandedNodes = collectExpandedNodes(treeView1.Nodes);
                //resetting tree view nodes status to colapsed
                treeView1.CollapseAll();
    
                //Restore it back
                if (ExpandedNodes.Count > 0)
                {
                    TreeNode IamExpandedNode;
                    for (int i = 0; i < ExpandedNodes.Count;i++ )
                    {
                        IamExpandedNode = FindNodeByName(treeView1.Nodes, ExpandedNodes[i]);
                        expandNodePath(IamExpandedNode);
                    }
                    
                }
    
            }
     
