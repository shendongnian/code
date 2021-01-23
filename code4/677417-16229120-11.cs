      private ViewModelLocator _locator = new ViewModelLocator();
      private void Window_Loaded(object sender, RoutedEventArgs e)
      {
        var viewModel = _locator.Print; // your ViewModel instance
        this.DataContext = viewModel;
        var datagrid = new DataGrid();
        var binding = new Binding("ViewFullRecipeGrouping");
        BindingOperations.SetBinding(datagrid, DataGrid.ItemsSource, binding);
      }
