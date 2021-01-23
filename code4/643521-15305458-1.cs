    public void OnGotFocus(object sender, RoutedEventArgs e)
    {
      TreeViewItem item = sender as TreeViewItem;
      
      if(((MyViewModel)item.Content).SomeColor == "Blue")
      {
        Grid g = VisualTreeHelper.GetChild(item, 0) as Grid;
        g.Background = Colors.Blue;
      }
    }
