    static class ListViewExtensions
    {
        public static IEnumerable<ListViewItem> SelectedListViewItems(this ListView listView)
        {
            return listView.SelectedItems.OfType<ListViewItem>();
        }
        public static IEnumerable<ListViewItem> ListViewItems(this ListView listView)
        {
            return listView.Items.OfType<ListViewItem>();
        }
    }
