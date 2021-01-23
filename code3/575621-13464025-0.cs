    async Task<IEnumerable<StorageFile>> FindMusicFiles()
    {
        var folderPicker = new FolderPicker()
        {
            CommitButtonText = "Yippie!",
            SuggestedStartLocation = PickerLocationId.ComputerFolder,
            ViewMode = PickerViewMode.List
        };
        folderPicker.FileTypeFilter.Add("*");
        StorageFolder folder = await folderPicker.PickSingleFolderAsync();
        if (folder != null)
        {
           StorageFileQueryResult queryResult = folder.CreateFileQuery();
           queryResult.ApplyNewQueryOptions(new QueryOptions(CommonFileQuery.OrderByName, new[] { ".mp3" }));
           IReadOnlyList<StorageFile> files = await queryResult.GetFilesAsync();
           return files;
        }
        return new StorageFile[] { };
    }
