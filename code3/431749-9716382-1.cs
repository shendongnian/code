    private void Button_Click(object sender, RoutedEventArgs e)
    {
      var scroller = GetScrollViewer();
      var listBox = GetListBox();
      double trueOffset;
      if (scroller.CanContentScroll)
      for (int i = 0; i < (int)scroller.VerticalOffset; i++)
      {
          var listBoxItem = (FrameworkElement)listBox.ItemContainerGenerator.ContainerFromIndex(i);
          trueOffset += listBoxItem.ActualHeight;        
      }
      else
          trueOffset = scroller.VerticalOffset;        
      this.Title = trueOffset.ToString();
    }
