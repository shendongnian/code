    private void cmnuAddNode_Click(object sender, EventArgs e)
        {
            NewNode n = new NewNode();
            n.ShowDialog();
            TreeNode nod = new TreeNode();
            nod.Name = n.NewNodeName.ToString();
            nod.Text = n.NewNodeText.ToString();
            n.Close();
      
            if (treeviewindex== 1)
            {
                treeView1.SelectedNode.Nodes.Add(nod);
                treeView1.SelectedNode.ExpandAll();
                
            }
            if (treeviewindex==2)
            {
                treeView2.SelectedNode.Nodes.Add(nod);
                treeView2.SelectedNode.ExpandAll();
            }
            if (treeviewindex == 3)
            {
                treeView3.SelectedNode.Nodes.Add(nod);
                treeView3.SelectedNode.ExpandAll();
            }
        }
