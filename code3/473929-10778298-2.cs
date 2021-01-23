    public static class ListViewExtensions
    {
        public static void SelectAll(this ListView lv)
        {
            foreach (ListViewItem item in lv.Items)
                item.Selected = true;
        }
    }
