    private async void GetPicturesFromGalleryFolder()
    {
        var queryOptions = new QueryOptions();
        queryOptions.FolderDepth = FolderDepth.Shallow;
        queryOptions.IndexerOption = IndexerOption.UseIndexerWhenAvailable;
        queryOptions.SortOrder.Clear();
        var sortEntry = new SortEntry {PropertyName = "System.DateModified", AscendingOrder = false};
        queryOptions.SortOrder.Add(sortEntry);
        queryOptions.FileTypeFilter.Add(".png");
        var fileQuery = KnownFolders.PicturesLibrary.CreateFileQueryWithOptions(queryOptions);
        var fileInformationFactory =
            new FileInformationFactory(
                fileQuery,
                ThumbnailMode.PicturesView,
                0,
                ThumbnailOptions.None,
                true);
        MyListView.ItemsSource = fileInformationFactory.GetVirtualizedFilesVector();
    }
