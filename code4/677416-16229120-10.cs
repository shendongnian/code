      private ViewModelLocator _locator = new ViewModelLocator();
      private void Window_Loaded(object sender, RoutedEventArgs e)
      {
        var viewModel = _locator.Print; // your ViewModel instance
        var datagrid = new DataGrid();
        datagrid.ItemsSource = viewModel.ViewFullRecipeGrouping;
      }
