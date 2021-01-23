    public void sendFile(LiveConnectClient liveClient, string fileName, string folderID) {
        using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication()) {
            Stream stream = storage.OpenFile(filepath, FileMode.Open);
            uploadFile(liveClient, stream, folderID, fileName);
        }
    }
