      private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
               if (treeView1.SelectedNode.Level == 2)
            {
              //text on the first level
                string text = treeView1.SelectedNode.Text;
               
            }
             else if (treeView1.SelectedNode.Level == 1)
            {
               //text on the second level 
                string text = treeView1.SelectedNode.Text;
               
            }
               
           
            }
