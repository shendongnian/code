    private void btnFind_Click(object sender, EventArgs e)
            {
                CallRecursive(treeView1);
            }
            private void PrintRecursive(TreeNode treeNode)
            {
    
                if (treeNode.Text.Contains(txtFind.Text.ToString()))
                {
                    //MessageBox.Show(treeNode.Text);
                    treeNode.BackColor = Color.Blue;
                }
                else
                {
                    treeNode.BackColor = Color.Empty;
                }
                // Print each node recursively.
    
                foreach (TreeNode tn in treeNode.Nodes)
                {
    
                    PrintRecursive(tn);
    
                }
    
            }
    
            // Call the procedure using the TreeView.
    
            private void CallRecursive(TreeView treeView)
            {
    
                // Print each node recursively.
    
                TreeNodeCollection nodes = treeView.Nodes;
    
                foreach (TreeNode n in nodes)
                {
    
                    PrintRecursive(n);
    
                }
    
            }
