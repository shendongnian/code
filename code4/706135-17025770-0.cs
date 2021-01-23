    LiveAuthClient authClient = new LiveAuthClient();
    LiveLoginResult authResult = await authClient.LoginAsync(new List<string>() { "wl.basic", "wl.skydrive", "wl.skydrive_update" });
    try
    {
        var folderData = new Dictionary<string, object>();
        folderData.Add("name", "Test Folder");
        LiveConnectClient liveClient = new LiveConnectClient(authResult.Session);
        LiveOperationResult operationResult =
            await liveClient.PostAsync("me/skydrive", folderData);
        dynamic result = operationResult.Result;
        var folderId = result.id;
        /*result is dynamic object, you can get the folder id with id property 
        operationResult.RawResult will return JSON response with some data related to 
        that folder */
    }
    catch (LiveConnectException exception)
    {
    }
