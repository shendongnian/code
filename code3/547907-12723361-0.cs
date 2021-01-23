    var destinationFolder = await KnownFolders.DocumentsLibrary.CreateFolderAsync("New Folder", CreationCollisionOption.GenerateUniqueName);
    
    var openpicker = new FileOpenPicker();
    openpicker.CommitButtonText = "Upload";
    openpicker.FileTypeFilter.Add(".jpg");
    openpicker.FileTypeFilter.Add(".jpeg");
    openpicker.FileTypeFilter.Add(".png");
    openpicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
    openpicker.ViewMode = PickerViewMode.List;
    
    file = await openpicker.PickSingleFileAsync();
    
       
    if (destinationFolder != null && file !=null)
    {
        await file.CopyAsync(destinationFolder);
        
    }
