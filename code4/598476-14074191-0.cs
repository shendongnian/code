    private void CellEditEndingEvent(object sender, RoutedEventArgs e)
    {
        var viewModel = (MyViewModel)DataContext;
        //Change params as needed
        if (viewModel.MyCommand.CanExecute(null))
            viewModel.MyCommand.Execute(null);
    }
