        HashSet<ListViewItem> indexesToRemove = new HashSet<ListViewItem>();
        foreach(ListViewItem item in listView1.Items)
        {
            if (item.SubItems[1].Text.ToLower().Contains(TextToFind) == false)
                indexesToRemove.Add(item);
        }
        listView1.BeginUpdate();
        foreach (ListViewItem lvItemToRemove in indexesToRemove)
            listView1.Items.Remove(lvItemToRemove);
        listView1.EndUpdate();
