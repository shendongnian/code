    private void treeView1_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            TreeViewHitTestInfo info = treeView1.HitTest(e.Location);
            treeView1.SelectedNode = info.Node;
    
            if (info.Node == null)
            {
                contextMenuStrip1.Show(Cursor.Position);
            }
            else
            {
                contextMenuStrip2.Show(Cursor.Position);
            }
        }
    }
