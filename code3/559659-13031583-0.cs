    Dictionary<string, List<string>> dict =
        FlickrListView.Items
                .Cast<ListViewItem>()
                .ToDictionary(
                    item => item.Text,
                    item => item.SubItems
                                .Cast<ListViewItem.ListViewSubItem>()
                                .Select(subItem => subItem.Text)
                                .ToList());
