    private void CommonClickHandler(object sender, RoutedEventArgs e)
    {
      FrameworkElement feSource = e.Source as FrameworkElement;
      if(feSource.Name == "MyCustomControlName")
      {
          //cancel whatever you want to cancel
          e.Handled=true;
      }
    }
