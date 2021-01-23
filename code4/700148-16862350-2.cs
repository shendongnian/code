	ListViewItem[] allElements = new ListViewItem[listView1.Items.Count];
        listView1.Items.CopyTo(allElements,0);
        List<ListViewItem> list = allElements.ToList();
        list.RemoveAll(item => item.SubItems[1].Text.ToLower().Contains(TextToFind) == false);
        listView1.BeginUpdate();
        listView1.Clear();
        listView1.Items.AddRange(list.ToArray());
        listView1.EndUpdate();
