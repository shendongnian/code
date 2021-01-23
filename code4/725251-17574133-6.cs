    private void ButtonBase_OnClick(object sender, RoutedEventArgs e) {
      TreeViewItem selectedItem = MyTreeView.SelectedItem as TreeViewItem;
      if (selectedItem != null) {
        selectedItem.IsSelected = false;
        MyTreeView.Focus();
      } else {
        Debug.WriteLine("Not TreeViewitem");
        Debug.WriteLine(MyTreeView.SelectedItem);
      }
    }
