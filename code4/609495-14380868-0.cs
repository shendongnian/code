    private void copyToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (listView1.SelectedItems.Count > 0)
        {
            System.Collections.Specialized.StringCollection sc = new System.Collections.Specialized.StringCollection();
            sc.Add(listView1.FocusedItem.Tag.ToString());
            Clipboard.SetFileDropList(sc);
        }
    }
