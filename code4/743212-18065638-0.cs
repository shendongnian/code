    //Gets selected item in TreeView
    private void Tree_One_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
           MainWindowViewModel.SelectedItem = e.NewValue as TreeViewItem;
           MainWindowViewModel.changeTab();
    }
