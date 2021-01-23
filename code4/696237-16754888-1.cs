        var item = ((Button)sender).DataContext;
        var itemIndex = list.Items.IndexOf(item);
        Global.operations.RemoveAt(itemIndex);
        var itemsView = CollectionViewSource.GetDefaultView(list.ItemsSource);
        itemsView.Refresh()
