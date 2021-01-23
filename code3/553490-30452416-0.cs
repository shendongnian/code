    private void listView1_MouseClick(object sender, MouseEventArgs e)
    {
        ListViewHitTestInfo hit = listView1.HitTest(e.Location);
        Rectangle rowBounds = hit.SubItem.Bounds;
        Rectangle labelBounds = hit.Item.GetBounds(ItemBoundsPortion.Label);
        int leftMargin = labelBounds.Left - 1;
        string x = hit.Item.Text;
    }
