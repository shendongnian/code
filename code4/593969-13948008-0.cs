    private void treeView1_MouseHover(object sender, EventArgs e)
    {
        TreeNode selNode =    (TreeNode)treeView1.GetNodeAt(treeView1.PointToClient(Cursor.Position));
    
        if (selNode != null)
        {
            // Do something...
        }
    }
