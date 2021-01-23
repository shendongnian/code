    FileOpenPicker openPicker = new FileOpenPicker();
    openPicker.ViewMode = PickerViewMode.Thumbnail;
    openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
    openPicker.FileTypeFilter.Add(".jpg");
    openPicker.FileTypeFilter.Add(".jpeg");
    openPicker.FileTypeFilter.Add(".png");
    
    StorageFile file = await openPicker.PickSingleFileAsync();
    if (file != null)
    {
        // Add to most recently used list with metadata (For example, a string that represents the date)
        string mruToken = Windows.Storage.AccessCache.StorageApplicationPermissions.MostRecentlyUsedList.Add(file, "20130622");
    
        // Add to future access list without metadata
        string faToken = Windows.Storage.AccessCache.StorageApplicationPermissions.FutureAccessList.Add(file);  
    }
    else
    {
        // The file picker was dismissed with no file selected to save
    }
