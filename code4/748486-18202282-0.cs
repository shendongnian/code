    // Helper to search up the VisualTree
    private static T FindAnchestor<T>(DependencyObject current)
        where T : DependencyObject
    {
       do
       {
          if (current is T)
          {
             return (T)current;
          }
          current = VisualTreeHelper.GetParent(current);
       }
       while (current != null);
       return null;
    }
    private void AvailableSignalsTreeView_SelectedItemChanged(
        object sender,
        RoutedPropertyChangedEventArgs<Object> e)
    {
        var treeViewItem = FindAnchestor<TreeViewItem>((DependencyObject)e.OriginalSource);
    }
    
