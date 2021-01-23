    public static List<ListViewItem> GetSelectedListViewItems(ListView lv)
    {
        if (!lv.InvokeRequired)
            return lv.SelectedItems.Cast<ListViewItem>().ToList();
        else
            return (List<ListViewItem>)lv.Invoke(
                new Func<ListView, List<ListViewItem>>(GetSelectedListViewItems),
                lv);
    }
