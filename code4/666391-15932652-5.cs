    private bool hasCheckedExistingFolder = false;
    private string storedFolderID;
    public void CreateFolder() {
        LiveConnectClient liveClient = new LiveConnectClient(session);
        // note that you should send a "liveClient.GetAsync("me/skydrive/files");" 
        // request to fetch the id of the folder if it already exists
        if (hasCheckedExistingFolder) {
          sendFile(liveClient, fileName, storedFolderID);
          return;
        }
        Dictionary<string, object> folderData = new Dictionary<string, object>();
        folderData.Add("name", "Smart GTD Data");
        liveClient.PostCompleted += onCreateFolderCompleted;
        liveClient.PostAsync("me/skydrive", folderData);
    }
      
    private void onCreateFolderCompleted(object sender, LiveOperationCompletedEventArgs e) {
        if (e.Result == null) {
            if (e.Error != null) {
              onError(e.Error);
            }
            return;
        }
        hasCheckedExistingFolder = true;
        // this is the ID of the created folder
        storedFolderID = (string)e.Result["data"];
        LiveConnectClient liveClient = (LiveConnectClient)sender;
        sendFile(liveClient, fileName, storedFolderID);
    }
