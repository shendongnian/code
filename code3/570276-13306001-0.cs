    var picker = new FolderPicker();
    picker.FileTypeFilter.Add("*");
    var folder = await picker.PickSingleFolderAsync();
     
    StorageApplicationPermissions.FutureAccessList.AddOrReplace(Token, folder);
