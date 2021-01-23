    private void listView_Click(object sender, EventArgs e)
    {
        Point mousePos = listView.PointToClient(Control.MousePosition);
        ListViewHitTestInfo hitTest = listView.HitTest(mousePos);
        int columnIndex = hitTest.Item.SubItems.IndexOf(hitTest.SubItem);
    }
