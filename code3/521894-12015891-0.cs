    void treeView1MouseUp(object sender, MouseEventArgs e)
    {
        if(e.Button == MouseButtons.Right)
        {
            // Select the clicked node
            treeView1.SelectedNode = treeView1.GetNodeAt(e.X, e.Y);
    
            if(treeView1.SelectedNode != null)
            {
            NewNode n = new NewNode();
            n.ShowDialog();
            TreeNode nod = new TreeNode();
            nod.Name = n.NewNodeName.ToString();
            nod.Text = n.NewNodeText.ToString();
            n.Close();   
            treeView1.SelectedNode.Nodes.Add(nod);
            treeView1.SelectedNode.ExpandAll();
            }
        }
    }
