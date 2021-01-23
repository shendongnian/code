    private bool _moviesLoaded;
    private bool _theatersLoaded;
    private void client_GetMoviesCompleted(object sender, ServiceReference1.GetMoviesCompletedEventArgs e)
    {
        Movies = e.Result;
        _moviesLoaded = true;
        TrySetDataIsLoaded();
    }
    private void client_GetTheatersCompleted(object sender, ServiceReference1.GetTheatersCompletedEventArgs e)
    {
        Theaters = e.Result;
        _theatersLoaded = true;
        TrySetDataIsLoaded();
    }
    private void TrySetDataIsLoaded()
    {
         if(_moviesLoaded && _theatersLoaded) this.IsDataLoaded = true;
    }
