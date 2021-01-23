    DirectorySearchModel _model = new DirectorySearchModel();
    void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        _model = new DirectorySearchModel();
        this.DataContext = _model ;
    }
    private void FindButton_Click(object sender, RoutedEventArgs e)
    {
        // use _model instead of "new DirectorySearchModel()" here
    }
