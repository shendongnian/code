    public static async Task<T> DownloadFileData<T>( string skydriveFileId, string isolatedStorageFileName )
        {
        var liveClient = new LiveConnectClient( Session );
        // Prepare for download, make sure there are no previous requests
        var reqList = BackgroundTransferService.Requests.ToList();
        foreach ( var req in reqList )
            {
            if ( req.DownloadLocation.Equals( new Uri( @"\shared\transfers\" + isolatedStorageFileName, UriKind.Relative ) ) )
                {
                BackgroundTransferService.Remove( BackgroundTransferService.Find( req.RequestId ) );
                }
            }
        // Download the file into IsolatedStorage file named @"\shared\transfers\isolatedStorageFileName"
        try
            {
            await liveClient.BackgroundDownloadAsync( skydriveFileId + "/Content", new Uri( @"\shared\transfers\" + isolatedStorageFileName, UriKind.Relative ) );
            }
        catch ( TaskCanceledException exception )
            {
            Debug.WriteLine( "Download canceled: " + exception.Message );
            }
        // Get a reference to the Local Folder
        var storageFolder = await GetSharedTransfersFolder<T>();
        // Read the file data
        var fileData = await StorageHelper.ReadFileAsync<T>( storageFolder, isolatedStorageFileName );
        return fileData;
        }
