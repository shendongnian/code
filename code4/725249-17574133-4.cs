    private void ButtonBase_OnClick(object sender, RoutedEventArgs e) {
      TreeViewItem selectedItem =
        MyTreeView.ItemContainerGenerator.ContainerFromItem(MyTreeView.SelectedItem) as TreeViewItem;
      if (selectedItem == null)
        return;
      selectedItem.IsSelected = false;
      MyTreeView.Focus();
    }
