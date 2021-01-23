    private static void OnSelectedItemPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
      ((BindableSelectedItemBehavior) sender).OnSelectedItemChanged(e.NewValue);
    }
    private void OnSelectedItemChanged(object newValue)
    {
      var treeViewItem = AssociatedObject.ItemContainerGenerator.ContainerFromItem(newValue) as TreeViewItem;
      treeViewItem.SetValue(TreeViewItem.IsSelectedProperty, true);
      treeViewItem.BringIntoView();
    }
