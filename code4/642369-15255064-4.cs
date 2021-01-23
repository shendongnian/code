    private void OnTreeItemClicked(object sender, MouseButtonEventArgs e)
    {
        _item = sender as TreeViewItem;
        if (_item != null)
        {
            string header = _item.Header.ToString();
        }
    }
