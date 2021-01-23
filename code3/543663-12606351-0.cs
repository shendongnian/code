    public Task<List<string>> GetImages()
    {
     var files = new List<string>();
     StorageFolder picturesFolder = KnownFolders.PicturesLibrary;
     IReadOnlyList<IStorageItem> itemsList = await picturesFolder.GetItemsAsync();
     foreach(var item in itemsList)
     {
      if(item is StorageFile)
      {
       files.Add(item.Name);
      }
     }
    return files;
    }
