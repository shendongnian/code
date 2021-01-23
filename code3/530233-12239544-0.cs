    void listview1_MouseUp(object sender, MouseEventArgs e)
        {
            ListViewItem item = listview1.GetItemAt(e.X, e.Y);
            ListViewHitTestInfo info = listview1.HitTest(e.X, e.Y);
            if ((item != null) && (info.SubItem != null))
            {
                //item.SubItems.IndexOf(info.SubItem) gives the column index
                MessageBox.Show(item.SubItems.IndexOf(info.SubItem).ToString());
            }
        }
