      private PrintViewModel _viewModel = new PrintViewModel();
      private void Window_Loaded(object sender, RoutedEventArgs e)
      {
        this.DataContext = _viewModel;
        var datagrid = new DataGrid();
        var binding = new Binding("ViewFullRecipeGrouping");
        BindingOperations.SetBinding(datagrid, DataGrid.ItemsSource, binding);
      }
