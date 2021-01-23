    private void cmnuAddNode_Click(object sender, EventArgs e,TreeViewEventArgs e1)
    {
        NewNode n = new NewNode();
        n.ShowDialog();
        TreeNode nod = new TreeNode();
        nod.Name = n.NewNodeName.ToString();
        nod.Text = n.NewNodeText.ToString();
        n.Close();
        if(e1.Node.TreeView == treeView1)
       {
        treeView1.SelectedNode.Nodes.Add(nod);
        treeView1.SelectedNode.ExpandAll();
        }
         if(e1.Node.TreeView == treeView2)
       {
        treeView2.SelectedNode.Nodes.Add(nod);
        treeView2.SelectedNode.ExpandAll();
         }
    }
