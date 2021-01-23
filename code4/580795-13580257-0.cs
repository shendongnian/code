    for (int i = 0; i < listView1.Items.Count; i++)
    {
        if (listView1.Items[i].SubItems[1].ToString() == item.SubItems[1].ToString())
        {
            listView1.Items[i] = (ListViewItem)item.Clone();
        }
    }
