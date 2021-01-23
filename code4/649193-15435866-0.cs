    foreach (var d in results)
    {
        ListViewItem lvi = new ListViewItem();
        foreach(ListViewItem.ListViewSubItem si in d.SubItems)
        {
            lvi.Add(new ListViewItem.ListViewSubItem(si.Text));
        }
        listQuery.Items.Add(lvi);
    }
