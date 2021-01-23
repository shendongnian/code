    private ListBoxItem FindItemContainer(DependencyObject obj)
    {
       while (obj != null && !(obj is ListBoxItem))
       {
           obj = VisualTreeHelper.GetParent(obj);
       }
    
       if (obj != null)
           return obj as ListBoxItem;
       else
           return null;
    }
    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
       var lbi = FindItemContainer(sender as DependencyObject);
       if (lbi != null)
       {
           if (lbi.IsSelected)
           {
               //do click event
           }
           else
               lbi.IsSelected = true;
       }
    }
