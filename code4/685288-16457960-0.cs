     private void treeView1_Click(object sender, EventArgs e)
     {
       TreeViewHitTestInfo info = treeView1.HitTest(treeView1.PointToClient(Cursor.Position));
       if (info != null)
         MessageBox.Show(info.Node.Text);
     }
