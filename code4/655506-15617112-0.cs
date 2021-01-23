    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (e.NavigationMode == NavigationMode.Back)
        {
            (this.DataContext as MainViewModel).LoadData();
        }
    }
