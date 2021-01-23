    treeView1.BeginUpdate();
    for (int i = 0; i < 4; ++i) {
      TreeNode tn = new TreeNode("Node #" + i.ToString());
      tn.Expand();
      for (int j = 0; j < 250; ++j) {
        tn.Nodes.Add("Child #" + j.ToString());
      }
     treeView1.Nodes.Add(tn);
    }
    treeView1.EndUpdate();
