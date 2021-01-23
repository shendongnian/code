        void treeView1MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                // Select the clicked node
                treeView1.SelectedNode = treeView1.GetNodeAt(e.X, e.Y);
        
                if(treeView1.SelectedNode != null)
                {
                 cmnuAddNode.Show(treeView1, e.Location);
                }
            }
        }
    
    //it will work for the two treeview getting Parent control of cmnuAddNode
    private void cmnuAddNode_Click(object sender, EventArgs e,TreeViewEventArgs e1)
        {
            TreeView yourtreeView = (TreeView)cmnuAddNode.Parent;
            NewNode n = new NewNode();
            n.ShowDialog();
            TreeNode nod = new TreeNode();
            nod.Name = n.NewNodeName.ToString();
            nod.Text = n.NewNodeText.ToString();
    
            n.Close();
     
            yourtreeView.SelectedNode.Nodes.Add(nod);
            yourtreeView.SelectedNode.ExpandAll();
    
        }
