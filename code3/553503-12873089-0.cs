       private void AddNodes()
        {
           TreeNode tn = new TreeNode() { Tag = Someform };
            //add nodes
            treeView1.NodeMouseClick += new TreeNodeMouseClickEventHandler(treeView1_NodeMouseClick);
        }
      void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            (e.Node.Tag as Form).Show();
        }
