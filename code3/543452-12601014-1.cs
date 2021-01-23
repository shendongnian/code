    protected async override void OnNavigatedTo(NavigationEventArgs e)
    {
        StorageFile f = await KnownFolders.MusicLibrary.GetFileAsync("video.mp4");
        BasicProperties bs = await f.GetBasicPropertiesAsync();
        // Do not create a new instance       
        ((MyClass) DataContext).Size = bs.Size;
    }
