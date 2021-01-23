    private void ItemMouseEnter(object sender, MouseEventArgs e)
    {
        if (!e.Handled)
        {
            var treeViewItem = sender as TreeViewItem;
            treeViewItem.Background = Brushes.LimeGreen;
            e.Handled = true;
        }
    }
