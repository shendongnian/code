    private static void CopySelectedItems(ListView listview1 , ListView listview2)
    {
        foreach (ListViewItem item in listview1 .SelectedItems)
        {
            listview2.Items.Add((ListViewItem)item.Clone());
        }
    }
