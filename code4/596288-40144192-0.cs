    private void MyTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MyContextMenu.Tag = e.Node;
                MyContextMenu.Show(this, e.Location);
            }
        }
    private void MyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Get TreeNode from Tag
            //Note: Could also get ContextMenu from sender,
            //but we already have it, so just access it directly
            TreeNode node = MyContextMenu.Tag as TreeNode;
            if (node == null)
                return;
            //Do stuff with node here
        }
