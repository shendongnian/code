	StorageFolderQueryResult queryResult = KnownFolders.RemovableDevices.CreateFolderQueryWithOptions(new QueryOptions(CommonFolderQuery.DefaultQuery));
	uint numItems = await queryResult.GetItemCountAsync();
	uint chunkSize = 50;
	for(uint startingIndex = 0; startingIndex < numItems; startingIndex += chunkSize)
	{
		var folderList = await queryResult.GetFoldersAsync(startingIndex, chunkSize);
		foreach (StorageFolder folder in folderList)
		{
			IReadOnlyList<StorageFile> fileList = await folder.GetFilesAsync(CommonFileQuery.DefaultQuery);
		    foreach (StorageFile file in fileList)
		    {
		    	BasicProperties properties = await file.GetBasicPropertiesAsync();
		    	size += properties.Size;
		    }
		}
	}	
