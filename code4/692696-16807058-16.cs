    private void Button_Click(object sender, RoutedEventArgs e)
    {
       var lbi = FindItemContainer(sender as DependencyObject);
       if (lbi != null)
       {
           if (lbi.IsSelected)
           {
               MainItem mainItem = lbi.Content as MainItem;
               ChildItem selChild = mainItem.ChildItems.MySelectedItem;
               if (selChild != null) mainItem.ChildItems.Items.Remove(selChild);
           }
           else
               lbi.IsSelected = true;
       }
    }
