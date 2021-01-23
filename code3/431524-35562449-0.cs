    int currentIndex = listView1.SelectedItems[0].Index;
    ListViewItem item = listView1.Items[currentIndex];
    if (currentIndex > 0)
    {
        listView1.Items.RemoveAt(currentIndex);
        listView1.Items.Insert(currentIndex - 1, item);
    }
    else
    {
        /*If the item is the top item make it the last*/
        listView1.Items.RemoveAt(currentIndex);
        listView1.Items.Insert(listView1.Items.Count, item);
    }
