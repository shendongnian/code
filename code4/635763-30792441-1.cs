    internal static class ListViewEx
    {
        internal static ListViewItem GetSelectedItem(this ListView listView1)
        {
            return (listView1.SelectedItems.Count > 0 ? listView1.SelectedItems[0] : null);
        }
    }
