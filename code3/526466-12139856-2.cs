    private void treeView1_MouseDown(object sender, MouseEventArgs e)
    {
        var hitTest = treeView1.HitTest(treeView1.PointToClient(e.Location));
        if (hitTest.Node != null)
        {
             treeView1.SelectedNode = hitTest.Node;
        }
    }
