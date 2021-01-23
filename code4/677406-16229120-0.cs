      private PrintViewModel _viewModel = new PrintViewModel();
      private void Window_Loaded(object sender, RoutedEventArgs e)
      {
        var datagrid = new DataGrid();
        datagrid.ItemsSource = _viewModel.ViewFullRecipeGrouping;
      }
