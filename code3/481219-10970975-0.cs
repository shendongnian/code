    private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
        if (e.Button == MouseButtons.Right) {
            treeView1.SelectedNode = e.Node;
            contextMenuStrip1.Show(treeView1, e.Location);
        }
    }
