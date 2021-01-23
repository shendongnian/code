    private void handleInner(object o, RoutedEventArgs e)
    {
        InnerControl innerControl = e.OriginalSource as InnerControl;
        if (innerControl  != null)
        {
            //do whatever
        }
        e.Handled = false;
    }
  
