    void myTreeView_MouseDown(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Right) {
        TreeNode tn = myTreeView.GetNodeAt(e.Location);
        if (tn != null) {
          myTreeView.SelectedNode = tn;
        }
      }
    }
