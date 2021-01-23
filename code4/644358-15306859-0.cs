    public async Task LoadDataAsync()
    {
        await FetchTileViewItemsAsync();
    }
    private async Task FetchTileViewItemsAsync()
    {
        var ret = await I2ADataServiceHelper.GetTileViewItemsAsync();
        this.Items = new ObservableCollection<TileViewItem>(ret);
        this.IsDataLoaded = true;
    }
    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
        if (!App.ViewModel.IsDataLoaded)
        {
            await App.ViewModel.LoadData();
        }
    }
