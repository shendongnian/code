    private void liveClient_DownloadCompleted(object sender, LiveDownloadCompletedEventArgs e)
    {
        Stream stream = e.Result;
        using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication())
        {
            using (IsolatedStorageFileStream fileToSave = storage.OpenFile("tasks.xml", FileMode.Create, FileAccess.ReadWrite))
            {
                stream.CopyTo(fileToSave);
                stream.Flush();
                stream.Close();
            }
        }
    }
