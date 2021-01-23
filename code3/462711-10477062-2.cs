    public static void CreateListViewItem(ListView listView, MyObject obj) {
        ListViewItem item = new ListViewItem();
        item.Tag = obj;
        
        // Other requirements as needed
        listView.Items.Add(item);
    }
