    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
        try
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                await App.ViewModel.LoadData();
            }
        }
        catch (Exception ex)
        {
            ...
        }
    }
