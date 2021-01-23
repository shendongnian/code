    void add_tooltiptext(DataTable mytab)
        {
            try
            {
                
                foreach (DataRow nodes in mytab.Rows)
                {
                    TreeNode[] found = treeView1.Nodes.Find(nodes["id"].ToString(), true);
                    for (int i = 0; i < found.Length; i++)
                    {
                        treeView1.SelectedNode = found[i];
                        
                        treeView1.SelectedNode.ToolTipText = nodes["description"].ToString();
                    }
                }
                
            }
            catch
            { }
        }
