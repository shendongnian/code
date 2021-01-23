    FilePickerSelectedFilesArray  files = await picker.PickMultipleFileAsync(); 
    for (var i = 0; i < files.size; i++) 
    {
         StorageFile newFile = await 
                 Windows.Storage.ApplicationData.Current.LocalFolder
                 .CreateFileAsync(files[1].Name); 
        await file.CopyAndReplaceAsync(newFile); 
        this.imageRelativePath = newFile.Path.Substring(
               newFile.Path.LastIndexOf("\\") + 1); 
        IWideTileNotificationContent tileContent = null; 
        ITileWideImage wideContent = TileContentFactory.CreateTileWideImage(); 
        wideContent.RequireSquareContent = false; 
        wideContent.Image.Src = "ms-appdata:///local/" + this.imageRelativePath; 
        wideContent.Image.Alt = "App data"; 
        tileContent = wideContent; 
        tileContent.RequireSquareContent = false; 
        TileUpdateManager.CreateTileUpdaterForApplication().Update(
              tileContent.CreateNotification()); 
    } 
