    ListViewItem[] collection = GetSelectedItems(listview);
    
    List<string> names = new List<string>();
    Parallel.ForEach(collection, item =>
    {
        User u = item.Tag as User;
        names.Add(u.Name);
    });
    private static ListViewItem[] GetSelectedItems(ListView listView)
    {
        ListViewItem[] selectedItems = new ListViewItem[0];
        MethodInvoker miGetSelectedItems = delegate
        {
            selectedItems = new ListViewItem[listview.SelectedItems.Count];
            listview.SelectedItems.CopyTo(selectedItems, 0);
        };
        if (listview.InvokeRequired)
        {
            listview.Invoke(miGetSelectedItems);
        }
        else
        {
            miGetSelectedItems();
        }
        return selectedItems;
    }
